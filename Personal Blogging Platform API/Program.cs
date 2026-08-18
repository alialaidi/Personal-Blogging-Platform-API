using Blog.Application.Interfaces;
using Blog.Application.Services;
using Blog.Infrastructure.Data;
using Blog.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString =
    builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddSingleton(
    new DbConnectionFactory(connectionString!));

builder.Services.AddScoped<IArticleRepository, ArticleRepository>();

builder.Services.AddScoped<IArticleService, ArticleService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();