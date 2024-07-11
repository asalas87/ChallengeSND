using ChallengeSND.Business.Servicies;
using ChallengeSND.Business.Servicies.Interfaces;
using ChallengeSND.Data.Repositories;
using ChallengeSND.Data.Repositories.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using ChallengeSND.Data.Models;
using ChallengeSND.Business.MappingProfiles;
using ChallengeSND.data.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.ClearProviders();
builder.Logging.AddConsole();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddAutoMapper(typeof(MedicoProfile),
                               typeof(PacienteProfile));

builder.Services.AddScoped<IMedicoRepository, MedicoRepository>();
builder.Services.AddScoped<IPacienteRepository, PacienteRepository>();
builder.Services.AddScoped<IMedicoService, MedicoService>();
builder.Services.AddScoped<IPacienteService, PacienteService>();
builder.Services.AddScoped<ChallengeSND.Business.Servicies.AuthenticationService>();
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7120") });

var tokenAppSetting = builder.Configuration.GetSection("Jwt");
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(cfg =>
    {
        cfg.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = tokenAppSetting.GetSection("Issuer").Value,
            ValidAudience = tokenAppSetting.GetSection("Audience").Value,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenAppSetting.GetSection("Key").Value)),
            RoleClaimType = "role"
        };
    });

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminPolicy", policy =>
        policy.RequireRole("Admin"));
});

builder.Services.Configure<ApiBehaviorOptions>(options => options.SuppressModelStateInvalidFilter = true);

var configuration = builder.Configuration;
var urls = configuration["urls"]?.Split(";") ?? new string[] { "http://localhost:5000" };
var localhostUrl = urls.FirstOrDefault(u => u.Contains("localhost"));
var port = new Uri(localhostUrl).Port;

var corsAllowedOrigin = $"https://localhost:{port}";

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.WithOrigins(corsAllowedOrigin)
               .AllowAnyHeader()
               .AllowAnyMethod();
    });
});

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "ChallengeSND API",
        Description = "API for ChallengeSND",
        Contact = new OpenApiContact
        {
            Name = "Support",
            Email = "support@challengeSND.com",
            Url = new Uri("https://www.challengeSND.com"),
        }
    });

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme. Enter 'Bearer' [space] and then your token in the text input below.\n\nExample: \"Bearer 12345abcdef\"",
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});

builder.Services.AddControllers();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ChallengeSND API v1"));
}

app.UseHttpsRedirection();
app.UseCors();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
