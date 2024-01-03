using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

const string securityKeyStr = "SuperSecurityKey_T3st$1234_donotuseitinprod.";
const string validIssuer = "https://localhost:7066";
const string validAudience = "https://localhost:7066";

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddSqlite<AppDbContext>("DataSource=app.db")
    .AddIdentityCore<AppUser>()
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<AppDbContext>();

builder.Services
    .AddHttpContextAccessor()
    .AddAuthorization(x =>
    {
        x.AddPolicy("AdminPolicy", p => p.RequireRole("ADMIN"));
    })
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = validIssuer,
            ValidAudience = validAudience,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKeyStr))
        };
    });


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();


var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};


app.MapGet("/weatherforecast", () =>
{
    var forecast = Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast")
.RequireAuthorization("AdminPolicy")
.WithOpenApi();


app.MapPost("/register", async (UserManager<AppUser> userManager) =>
{
    var user = new AppUser
    {
        UserName = "TestUser",
        Email = "testuser@email.com"
    };

    var result = await userManager.CreateAsync(user, "Test.1234!");

    return Results.Ok(result);
});

app.MapPost("/token", async (AuthenticateRequest request, UserManager<AppUser> userManager) =>
{
    var user = await userManager.FindByNameAsync(request.UserName);

    if (user is null || !await userManager.CheckPasswordAsync(user, request.Password))
    {
        return Results.Forbid();
    }

    var roles = await userManager.GetRolesAsync(user);

    var claims = new List<Claim>
    {
        new Claim(ClaimTypes.Sid, user.Id),
        new Claim(ClaimTypes.Name, user.UserName)
    };

    foreach (var role in roles)
    {
        claims.Add(new Claim(ClaimTypes.Role, role));
    }

    //test
    //claims.Add(new Claim(ClaimTypes.Role, "ADMIN"));

    var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKeyStr));
    var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
    var tokenDescriptor = new JwtSecurityToken(
        issuer: validIssuer,
        audience: validAudience,
        claims: claims,
        expires: DateTime.Now.AddMinutes(720),
        signingCredentials: credentials);

    var jwt = new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);

    return Results.Ok(new
    {
        AccessToken = jwt
    });
});

//Not really needed, directly can be injected ClaimsPrincipal
app.MapGet("/me", (IHttpContextAccessor contextAccessor) =>
{
    var user = contextAccessor.HttpContext.User;

    return Results.Ok(new
    {
        Claims = user.Claims.Select(s => new
        {
            s.Type,
            s.Value
        }).ToList(),
        user.Identity.Name,
        user.Identity.IsAuthenticated,
        user.Identity.AuthenticationType
    });
})
.RequireAuthorization();

app.Run();





public record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}


public class AppUser : IdentityUser
{

}

public class AppDbContext : IdentityDbContext<AppUser>
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    { }
}

public record AuthenticateRequest(string UserName, string Password);