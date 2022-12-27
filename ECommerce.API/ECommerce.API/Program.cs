using Microsoft.EntityFrameworkCore;
using ECommerce.Models;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connValue = builder.Configuration["ECommerce:ConnectionString"];

builder.Services.AddDbContext<Context>(opt => opt.UseSqlServer(connValue));

builder.Services.AddScoped<IContext>(provider => provider.GetService<Context>());

var ECommerceAPI = "_ECommerceAPI";

builder.Services.AddCors(options => {
    options.AddPolicy(name: ECommerceAPI,
        policy =>
        {
            policy.WithOrigins("http://localhost:4200")
                   .AllowAnyMethod()
                   .AllowAnyHeader()
                   .AllowCredentials();
        });
});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
