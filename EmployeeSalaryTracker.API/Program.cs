using AutoMapper;
using EmployeeSalaryTracker.API.Profiles;
using EmployeeSalaryTracker.Data.Data;
using EmployeeSalaryTracker.Data.Repositories;
using EmployeeSalaryTracker.Data.Repositories.Interfaces;
using EmployeeSalaryTracker.Service.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Logging.AddDebug();


builder.Services.AddDbContext<EmployeeSalaryTrackerData>(opts =>
    opts.UseInMemoryDatabase("EmployeeSalaryTrackerDb"));

builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IMapper>(_ =>
    new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>())
        .CreateMapper()
);

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});


var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    DataSeeder.SeedData(scope.ServiceProvider);
}


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();
app.UseRouting();
app.UseCors();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});
app.Run();

