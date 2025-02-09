using AutoCareAPI.Helpers;
using AutoCareAPI.Repositories;
using AutoCareAPI.Repositories.Interfaces;
using AutoCareAPI.Services;
using AutoCareAPI.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var config = builder.Configuration;

builder.Services.AddControllers();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAny", build => build.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader().AllowCredentials());
});
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    string jwtKey = config["Jwt:Key"];
    if (string.IsNullOrEmpty(jwtKey))
    {
        throw new InvalidOperationException("Jwt:Key configuration value is missing.");
    }
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = config["Jwt:Issuer"],
        ValidAudience = config["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey))
    };
});
//builder.Services.AddAuthentication();
builder.Services.AddScoped<IUserRepo, UserRepo>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<ICommonRepo, CommonRepo>();
builder.Services.AddScoped<ICommonService, CommonService>();
builder.Services.AddSingleton<dbHelper>();
builder.Services.AddScoped<JwtHelper>();
var app = builder.Build();

// Configure the HTTP request pipeline.


app.UseDefaultFiles();
app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseRouting();
app.UseCors("AllowAny");
app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name:"default",
        pattern:"api/{controller}/{action=Index}/{id?}");
});

app.Run();
