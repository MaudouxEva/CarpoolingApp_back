using System.Text;
using CarpoolingApp.DB.Contexts;
using CarpoolingApp.IL.Configurations;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// configuration de la connectionString
string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<CarpoolingAppContext>(options => {
    options.UseNpgsql(connectionString);
});

// configuration de Jwt
JwtConfiguration jwtConfig = builder.Configuration.GetSection("JwtSettings") 
    .Get<JwtConfiguration>()
    ?? throw new Exception("Jwt Config is missing");
builder.Services.AddSingleton(jwtConfig);  // singleton pour éviter de le recharger à chaque fois

// configuration de l'authentification Jwt 
builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options => 
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = jwtConfig.ValidateIssuer,
            ValidateAudience = jwtConfig.ValidateAudience,
            ValidateLifetime = jwtConfig.ValidateLifeTime,
            ValidIssuer = jwtConfig.Issuer,
            ValidAudience = jwtConfig.Audience,
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(jwtConfig.Signature)
            )
        };
    });


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication(); // ajout de l'authentification Jwt

app.UseAuthorization(); 

app.MapControllers();

app.Run();