using Meetup.Api.Infrastructure.Configurations;
using Meetup.Api.Infrastructure.MappingProfiles;
using Meetup.Api.Infrastructure.Middlewares;
using Meetup.BusinessLayer;
using Meetup.DataLayer;
using Microsoft.AspNetCore.Authentication.JwtBearer;

var builder = WebApplication.CreateBuilder(args);

builder
    .AddAppSettings()
    .AddJWTVerifierSettings();

builder.Services
    .AddAutoMapper(typeof(MappingProfile))
    .AddMeetupService()
    .AddMeetingDatabase(builder.Configuration)
    .AddJWTVerifier();

builder.Services.AddAuthentication(option =>
{
    option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseMiddleware<JWTMiddleware>();

app.UseAuthorization();

app.MapControllers();

app.Run();


namespace Meetup
{
    public partial class Program { }
}