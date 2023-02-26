using Product.Business.Business;
using Product.Business.Interface;
using Product.Entity.Entity;
using Product.Interface.Interface;
using Product.Service.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


/// DB connections
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ForSaleConnectionsString")));

//Add AutomapperService
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

//Dependency injection
builder.Services.AddScoped<IProduct, ProductService>();
builder.Services.AddScoped<IProductBusiness, ProdcutBusiness>();

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
