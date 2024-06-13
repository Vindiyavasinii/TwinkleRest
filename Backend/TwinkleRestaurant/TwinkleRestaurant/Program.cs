using Microsoft.EntityFrameworkCore;
using TwinkleRestaurant.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AppsDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("AppsContext")));
builder.Services.AddCors(options =>
{
    options.AddPolicy("MyCorsPolicy", builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


// Add other services



if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseRouting();

app.UseAuthorization();

app.UseCors("MyCorsPolicy");

app.UseAuthentication();

app.MapControllers();

app.Run();
