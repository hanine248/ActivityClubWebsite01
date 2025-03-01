using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using ActivityClub.Services;
using ActivityClub.Services.IServices;
using Microsoft.OpenApi.Models;
using ActivityClub.Core.Repositories.IRepositories;
using ActivityClub.Core.Repositories;
using ActivityClub.Core.Models;
using ActivityClub.API.Mapping;
using AutoMapper;

var builder = WebApplication.CreateBuilder(args);

// Configure Database Context
builder.Services.AddDbContext<ActivityClubContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
});

// Add CORS configuration
builder.Services.AddCors(options =>
{
    //options.AddPolicy("CorsPolicy",
    //    builder =>
    //    {
    //        builder.WithOrigins("http://localhost:5049") // Update with your actual URL
    //               .AllowAnyMethod()
    //               .AllowAnyHeader()
    //               .AllowCredentials(); // Allow credentials if needed
    //    });


    options.AddPolicy("CorsPolicy", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });

});

// Add services to the container.
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve; // Handle circular references
    });

// JWT Authentication Configuration
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = "Bearer";
    options.DefaultChallengeScheme = "Bearer";
})
.AddJwtBearer("Bearer", options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],  // From appsettings.json
        ValidAudience = builder.Configuration["Jwt:Audience"], // From appsettings.json
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])) // From appsettings.json
    };
});

// Dependency Injection
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IAdminService, AdminService>();
builder.Services.AddTransient<IGuideService, GuideService>();
builder.Services.AddTransient<IMemberService, MemberService>();
builder.Services.AddTransient<IEventService, EventService>();
builder.Services.AddTransient<IEventMemberService, EventMemberService>();
builder.Services.AddTransient<IEventGuideService, EventGuideService>();

// Inject Auth Services
builder.Services.AddTransient<IAuthenticationService, AuthenticationService>();

// Add AutoMapper
builder.Services.AddAutoMapper(typeof(ProfileMapping)); // Register AutoMapper profile
builder.Services.AddLogging(logging =>
{
    logging.AddConsole();
    logging.AddDebug();
});

// Swagger/OpenAPI Configuration
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme. Example: 'Bearer {token}'",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
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
            new string[] { }
        }
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API v1");
    });
}

// Enable CORS middleware
app.UseCors("CorsPolicy");

// Enable Authentication and Authorization Middleware
app.UseAuthentication(); // Add this before UseAuthorization
app.UseAuthorization();

app.MapControllers();

app.Run();
