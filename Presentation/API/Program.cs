using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using ToDoApp.Application;
using ToDoApp.Application.Exceptions;
using ToDoApp.Application.Options;
using ToDoApp.Application.Security;
using ToDoApp.Persistence;

var builder = WebApplication.CreateBuilder(args);


var jwtAuth = builder.Configuration.GetSection("JwtAuth").Get<JwtAuth>() ?? throw new InvalidOperationException("JwtAuth configuration is missing.");
builder.Services.AddSingleton(jwtAuth);
builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtAuth.Key)),
        ValidateAudience = false,
        ValidateIssuer = false,
        ValidateLifetime = true,
        ClockSkew = TimeSpan.Zero
    };
});
builder.Services.AddHttpContextAccessor();
builder.Services.AddApplicationServices();
builder.Services.AddPersistenceServices(builder.Configuration);


// Add services to the container.

builder.Services.AddControllers();
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

app.UseMiddleware<ExceptionHandlingMiddleware>();
app.UseAuthentication();
app.UseAuthorization();

app.UseAuthorization();

app.MapControllers();

app.MapPost("/api/Auth/me", (IUserContextProvider userContextProvider) =>
{
    return Results.Ok(new
    {
        userContextProvider.UserName,
        userContextProvider.Roles,
        userContextProvider.IsAuthenticated
    });
}).RequireAuthorization();

app.Run();
