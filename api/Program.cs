using api.Data;
using api.Interfaces;
using api.Repository;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddControllers();

builder.Services.AddControllers().AddNewtonsoftJson( options =>
{
    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
});

var connectionString = builder.Configuration.GetValue<string>("DB_CONNECTION_STRING") ??
                       builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(connectionString);
});

builder.Services.AddScoped<IStockRepository, StockRepository>();
builder.Services.AddScoped<ICommentRepository, CommentRepository>();


var app = builder.Build();


app.MapOpenApi();
app.MapScalarApiReference();

app.UseHttpsRedirection();
app.MapControllers();

app.Run();

