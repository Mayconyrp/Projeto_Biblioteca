using Microsoft.EntityFrameworkCore;
using ProjetoBiblioteca.Context;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string conexaosql = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(conexaosql,
    ServerVersion.AutoDetect(conexaosql)));

builder.Services.AddCors(options => {
    options.AddPolicy(name: "MinhaPolitica",
        policy =>
        {
            policy.WithOrigins("http://localhost:5020", "http://127.0.0.1:5500", "http://localhost:5500", " http://192.168.56.1:3000")
            .AllowAnyHeader()
            .AllowAnyMethod();
        });

});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("MinhaPolitica");

app.UseAuthorization();

app.MapControllers();

app.Run();