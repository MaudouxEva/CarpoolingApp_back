using System.Text;
using CarpoolingApp.BLL.Interfaces;
using CarpoolingApp.BLL.Services;
using CarpoolingApp.DAL.Interfaces;
using CarpoolingApp.API.DependencyInjections;
using CarpoolingApp.DAL.Repositories;
using CarpoolingApp.IL.Configurations;
using CarpoolingApp.IL.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Net.Http.Headers;
using Microsoft.OpenApi.Models;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);


// Lecture de la connectionString
string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
// builder.Services.AddDbContext<CarpoolingAppContext>(options => {
//     options.UseNpgsql(connectionString);
// });

// Lecture + enregistrement de la config JWT
JwtConfiguration jwtConfig = builder.Configuration.GetSection("JwtSettings") 
    .Get<JwtConfiguration>()
    ?? throw new Exception("Jwt Config is missing");
// builder.Services.AddSingleton(jwtConfig);  // singleton pour éviter de le recharger à chaque fois

// configuration de l'authentification Jwt 
// builder.Services
//     .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
//     .AddJwtBearer(options => 
//     {
//         options.TokenValidationParameters = new TokenValidationParameters
//         {
//             ValidateIssuer = jwtConfig.ValidateIssuer,
//             ValidateAudience = jwtConfig.ValidateAudience,
//             ValidateLifetime = jwtConfig.ValidateLifeTime,
//             ValidIssuer = jwtConfig.Issuer,
//             ValidAudience = jwtConfig.Audience,
//             IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtConfig.Signature)
//             )
//         };
//     });

// Ajouter les services
builder.Services.AddDatabase(connectionString); // Ajout de la connexion à la DB
builder.Services.AddJwt(jwtConfig); // Ajout de la config Jwt
builder.Services.AddDALRepositories();
builder.Services.AddBLLServices();
builder.Services.AddSwagger();
builder.Services.AddControllers();
// Add Swagger
builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen(c =>
// {
//     // On rajoute la doc
//     c.SwaggerDoc("v1", new OpenApiInfo { Title = "Carpooling API", Version = "v1" });
//
//     //  On ajoute la config pour JWT
//     var securitySchema = new OpenApiSecurityScheme
//     {
//         Name = "Authorization",
//         In = ParameterLocation.Header,
//         Type = SecuritySchemeType.Http,
//         Scheme = "bearer",
//         BearerFormat = "JWT",
//         Description = "JWT Authorization header using the Bearer scheme. Enter 'Bearer' [space] and then your token.",
//         Reference = new OpenApiReference
//         {
//             Type = ReferenceType.SecurityScheme,
//             Id = "Bearer"
//         }
//     };
//     c.AddSecurityDefinition("Bearer", securitySchema);
//     c.AddSecurityRequirement(new OpenApiSecurityRequirement
//     {
//         {
//             securitySchema,
//             new string[] {}
//         }
//     });
// });

// // Register de IJwtManager / AuthService / Repos
// builder.Services.AddScoped<IJwtManager, JwtManager>();
// builder.Services.AddScoped<IAuthService, AuthService>(); 
// builder.Services.AddScoped<IUserRepository, UserRepository>();


// Configuration des requetes "Cross Origin"
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", policy =>
    {
        // policy
        //     .WithOrigins("http://localhost:4200")
        //     .AllowAnyHeader()
        //     .AllowAnyMethod()
        //     .AllowCredentials();
        policy
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });

    // - Regle nommé
    options.AddPolicy("header_api", policy =>
    {
        // Config : Le header restraint
        // - Avec une clef avec une valeur spécifique
        policy.WithHeaders(HeaderNames.ContentType, "application/json");
        // - Avec la presence d'une clef
        policy.WithExposedHeaders("app-key");
    });
});



WebApplication app = builder.Build();

// Pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("CorsPolicy");
app.UseHttpsRedirection();

// Activer l'authentification + autorisation
app.UseAuthentication();
app.UseAuthorization(); 

app.MapControllers();

app.Run();