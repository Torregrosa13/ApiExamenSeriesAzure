using ApiExamenSeriesAzure.Data;
using ApiExamenSeriesAzure.Repositories;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

string connectionString = builder.Configuration.GetConnectionString("SqlAzure");
builder.Services.AddDbContext<SeriesContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddTransient<RepositorySeries>();
builder.Services.AddOpenApi();
builder.Services.AddControllers();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapScalarApiReference();
}

app.MapOpenApi();
app.UseHttpsRedirection();

app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/openapi/v1.json", "Api Examen Series");
    options.RoutePrefix = "";
});

app.UseAuthorization();

app.MapControllers();

app.Run();

