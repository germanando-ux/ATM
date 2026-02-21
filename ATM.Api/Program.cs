
using ATM.Data.Data;
using ATM.Data.Repositories;
using ATM.Data.Services;
using ATM.Domain.Interface;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ATMDbContext>(options =>options.UseInMemoryDatabase("ATM_Db"));


builder.Services.AddScoped<IBankAccountRepository, BankAccountRepository>();

builder.Services.AddControllers();
builder.Services.AddOpenApi();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<ATMDbContext>();
    DbDataSeeder.Seed(context);
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
