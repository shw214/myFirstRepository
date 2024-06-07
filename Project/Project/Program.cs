// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;
using Project.BLL;
using Project.DAL;
using Project.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using AutoMapper;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ICategoryDal, CategoryDal>();

builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<ICustomerDal, CustomerDal>();

builder.Services.AddScoped<IDonorService, DonorService>();
builder.Services.AddScoped<IDonorDal, DonorDal>();

builder.Services.AddScoped<IPresentService, PresentService>();
builder.Services.AddScoped<IPresentDal, PresentDal>();

builder.Services.AddScoped<IPurchaseService, PurchaseService>();
builder.Services.AddScoped<IPurchaseDal, PurchaseDal>();

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();
builder.Services.AddDbContext<OrdersContext>(c => c.UseSqlServer("Data Source=srv2\\pupils;Initial Catalog=326083458DB;Integrated Security=True;Trust Server Certificate=True;"));
/*builder.Services.AddCors(options =>
{
    options.AddPolicy("myAppCors", policy =>
    {
        policy.WithOrigins("http://localhost:3000/")
                .AllowAnyHeader()
                .AllowAnyMethod();
    });
});*/

var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:3000"));
/*builder.Services.AddCors();*/
//app.UseCors("myAppCors");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

