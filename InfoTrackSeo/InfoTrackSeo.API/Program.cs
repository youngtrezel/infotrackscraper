using InfoTrackSeo.API.Handlers;
using InfoTrackSeo.API.Interfaces;
using InfoTrackSeo.API.Middleware;
using InfoTrackSeo.API.Validation;
using InfoTrackSeo.Common.Models;
using InfoTrackSeo.Data;
using InfoTrackSeo.Repositories;
using InfoTrackSeo.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder => builder.WithOrigins("http://localhost:4200")
                            .AllowAnyMethod()
                            .AllowAnyHeader());
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddHttpClient<SearchEngineCountHandler>();
builder.Services.AddScoped<ISearchEngineCountHandler, SearchEngineCountHandler>();
builder.Services.AddScoped<IValidate<SearchEngineRequest>, RequestValidation>();

builder.Services.AddScoped<ISearchEngineCountTrendRepository, SearchEngineCountTrendRepository>();
builder.Services.AddDbContext<SECountTrendContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DbContext")));


var app = builder.Build();
app.UseStatusCodePages();
app.UseCors("AllowSpecificOrigin");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseAuthorization();

app.MapControllers();

app.Run();
