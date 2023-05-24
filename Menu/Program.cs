using Menu.DLL.Data;
using Menu.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Menu.DLL.Interfaces;
using Menu.DLL.Repositories;
using Menu.BLL.interfaces;
using Menu.BLL.Services;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddTransient<IMenuListServices, MenuListServices>();
builder.Services.AddTransient<ICategoryServices, CategoryServices>();
builder.Services.AddTransient<IDishesServices, DishesServices>();
builder.Services.AddTransient<IMenuDishesServices, MenuDishesServices>();
builder.Services.AddTransient<IRatingServices, RatingServices>();

builder.Services.AddScoped<IMenuListRepository, MenuListRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IDishesRepository, DishesRepository>();
builder.Services.AddScoped<IMenuDishesRepository, MenuDishesRepository>();
builder.Services.AddScoped<IRatingRepository, RatingRepository>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//Подключаем контекст БД
var connection = builder.Configuration.GetSection("DB").Value;
builder.Services.AddDbContext<AppDBContext>(options => options.UseSqlServer(connection));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
