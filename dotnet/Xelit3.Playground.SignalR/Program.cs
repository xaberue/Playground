using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Xelit3.Playground.SignalR.Hubs;
using Xelit3.Playground.SignalR.Services;


var builder = WebApplication.CreateBuilder(args);

var validIssuer = builder.Configuration["JwtSettings:Issuer"];
var validAudience = builder.Configuration["JwtSettings:Audience"];
var key = builder.Configuration["JwtSettings:Key"]!;

builder.Services.AddControllersWithViews();
builder.Services.AddSignalR();

builder.Services.AddSingleton<IUserService, UserService>();

builder.Services.AddDbContextFactory<AppDbContext>(opt =>
{
    opt.UseSqlite("DataSource=signalr-app.db");
});

builder.Services.AddHttpContextAccessor();

builder.Services
    .AddDefaultIdentity<AppUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<AppDbContext>();


builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(opt =>
    {
        opt.TokenValidationParameters = new TokenValidationParameters
        {
            ValidIssuer = validIssuer,
            ValidAudience = validAudience,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key)),
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true
        };

        opt.Events = new JwtBearerEvents
        {
            OnMessageReceived = context =>
            {
                var accessToken = context.Request.Query["access_token"];

                // If the request is for our hub...
                var path = context.HttpContext.Request.Path;
                if (!string.IsNullOrEmpty(accessToken) &&
                    (path.StartsWithSegments("/user-counter")))
                {
                    // Read the token out of the query string
                    context.Token = accessToken;
                }
                return Task.CompletedTask;
            }
        };
    });

builder.Services.AddAuthorization();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapPost("/auth/token", async (AuthenticateRequest request, UserManager<AppUser> userManager, IUserService userService) =>
{
    var internalUser = userService.Get(request.UserId);

    var user = await userManager.FindByNameAsync(internalUser.Email);

    if (user is null || !await userManager.CheckPasswordAsync(user, request.Password))
    {
        return Results.Forbid();
    }

    var roles = await userManager.GetRolesAsync(user);

    var claims = new List<Claim>
    {
        new Claim(ClaimTypes.Sid, user.Id),
        new Claim(ClaimTypes.NameIdentifier, user.Id),
        new Claim(ClaimTypes.Name, user.UserName),
        new Claim(ClaimTypes.Email, user.Email),
    };

    foreach (var role in roles)
    {
        claims.Add(new Claim(ClaimTypes.Role, role));
    }

    //test
    //claims.Add(new Claim(ClaimTypes.Role, "ADMIN"));

    var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.MapHub<UserCounterHub>("/user-counter");

app.Run();




public class AppUser : IdentityUser { }

public class AppDbContext : IdentityDbContext<AppUser>
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    { }
}


public record AuthenticateRequest(int UserId, string Password);