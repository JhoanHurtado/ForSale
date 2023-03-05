using Users.Business.Business;
using Users.Business.Intefaces;
using Users.Interfaces.Interfaces;
using Users.Services.Services;
using Microsoft.EntityFrameworkCore;
using Users.Entity.Entities;

var builder = WebApplication.CreateBuilder(args);

/// DB connections
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ForSaleConnectionsString")));

//Add AutomapperService
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

//Dependency injection
builder.Services.AddScoped<IUserInterfaces, UserServices>();
builder.Services.AddScoped<IUserBusiness, UserBusiness>();

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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
