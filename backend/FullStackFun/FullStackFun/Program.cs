using FullStackFun.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(); 
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<BowlerDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("BowlingConnection")));

builder.Services.AddCors();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(x => x.WithOrigins("http://localhost:3000"));

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers(); 

app.Run();