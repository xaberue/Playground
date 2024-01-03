using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using Xelit3.Playground.API.Grpc.Security;
using Xelit3.Playground.API.Grpc.Services;
using Xelit3.Playground.API.Shared.Data;
using Xelit3.Playground.API.Shared.Models;


const string securityKeyStr = "SuperSecurityKey_T3st$1234_donotuseitinprod.";
const string validIssuer = "https://localhost:7066";
const string validAudience = "https://localhost:7066";


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ToDoDataContext>(opt =>
{
    opt.UseSqlite("Data Source=ToDoDatabase.db");
});
builder.Services.AddDbContext<AppIdentityDbContext>(opt =>
{
    opt.UseSqlite("Data Source=ToDoDatabase.db");
});

builder.Services
    .AddIdentityCore<AppUser>(opt => 
    {
        opt.User.RequireUniqueEmail = true;
    })
    .AddRoles<IdentityRole>()
    .AddClaimsPrincipalFactory<UserClaimsPrincipalFactory<AppUser, IdentityRole>>()
    .AddSignInManager<SignInManager<AppUser>>()
    .AddEntityFrameworkStores<AppIdentityDbContext>()
    .AddDefaultTokenProviders();

builder.Services
    .AddAuthorization(x =>
    {
        x.AddPolicy("AdminPolicy", policy => policy.RequireClaim("Admin"));
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

builder.Services.AddGrpc().AddJsonTranscoding();
builder.Services.AddGrpcReflection();
builder.Services.AddGrpcSwagger();
builder.Services.AddSwaggerGen(x =>
{
    x.SwaggerDoc("v1", new OpenApiInfo { Title = "ToDo API", Version = "v1" });
});

var authSettings = new AuthSettings 
{
    SecretKey = securityKeyStr,
    MinutesToExpire = 10,
    SiteName = validIssuer
};

builder.Services.AddSingleton(authSettings);
builder.Services.AddTransient<ITokenHelper, TokenHelper>();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(x =>
    {
        x.SwaggerEndpoint("/swagger/v1/swagger.json", "ToDo API v1");
    });
}

app.UseAuthentication();
app.UseAuthorization();

app.MapGrpcService<TodoService>();
app.MapGrpcService<AuthService>();


if (app.Environment.IsDevelopment())
{
    app.MapGrpcReflectionService();
}

app.Run();
