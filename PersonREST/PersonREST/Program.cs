using PersonREST.Services.Implementations;
using Microsoft.EntityFrameworkCore;
using PersonREST.Model.Context;

var builder = WebApplication.CreateBuilder(args);


// Load configuration from appsettings.json
builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
var connection = builder.Configuration["MySQLConnection:MySQLConnectionString"];
//builder.Services.AddApiVersioning();
builder.Services.AddScoped<IPersonService, PersonServiceImplementation>();
builder.Services.AddDbContext<MySQLContext>(options => options.UseMySql(connection, ServerVersion.AutoDetect(connection)));
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