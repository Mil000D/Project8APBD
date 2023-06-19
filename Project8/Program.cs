using Newtonsoft.Json;
using Zadanie8.Mapper;
using Zadanie8.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Zadanie8.TokenCreator;
using Zadanie8.Middlewares;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<MainDbContext>();
builder.Services.AddTransient<IMapDoctorToDTO,  MapDoctorToDTO>();
builder.Services.AddTransient<IMapPrescriptionToDTO, MapPrescriptionToDTO>();
builder.Services.AddTransient<ITokenCreator, TokenCreator>();
// Add services to the container

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ClockSkew = TimeSpan.FromMinutes(1),
        ValidIssuer = "https://localhost:8888",
        ValidAudience = "https://localhost:8888",
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("longsecretkeylongsecretkeylongsecretkeylongsecretkeylongsecretkeylongsecretkeylongsecretkey"))
    };
});
builder.Services.AddControllers()
                .AddNewtonsoftJson(opt =>
                {
                    opt.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                });
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseErrorHandling();

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
