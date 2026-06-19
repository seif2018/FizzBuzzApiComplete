using FizzBuzz.Api.Domain;
using FizzBuzz.Api.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHealthChecks();
builder.Services.AddScoped<IFizzBuzzService, FizzBuzzService>();

var allowedOrigins = builder.Configuration.GetSection("Cors:AllowedOrigins").Get<string[]>() ?? Array.Empty<string>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("FrontendPolicy", policy =>
    {
        policy.WithOrigins(allowedOrigins).AllowAnyHeader().AllowAnyMethod();
    });
});

var app = builder.Build();

app.UseMiddleware<ValidationExceptionMiddleware>();
app.UseSwagger();
app.UseSwaggerUI();
app.UseCors("FrontendPolicy");
app.MapControllers();
app.MapHealthChecks("/health");
app.Run();

public partial class Program { }
