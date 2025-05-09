using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer("Bearer", options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false, // não valida o emissor
            ValidateAudience = false, // não valida o público
            ValidateLifetime = true, // valida o tempo de vida do token
            ValidateIssuerSigningKey = true, // valida a chave de assinatura. * Mais importante do que vlaidar o emissor
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.ASCII.GetBytes("chave-super-secreta-para-desenvolvimento"))
        };
    });

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("ApiScope", policy =>
    {
        policy.RequireAuthenticatedUser()
            .RequireClaim("scope", "teste");
    });

    options.AddPolicy("SomenteAdmin1", policy =>
    {
        policy.RequireAuthenticatedUser()
            .RequireRole("admin")
            .RequireClaim(ClaimTypes.NameIdentifier, "1");
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
