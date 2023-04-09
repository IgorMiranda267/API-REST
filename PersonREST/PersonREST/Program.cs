using Microsoft.EntityFrameworkCore;
using PersonREST.Model.Context;
using PersonREST.Services.Implementations;


var builder = WebApplication.CreateBuilder(args);

//Conex�o com o Banco de Dados.
builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
string connection = builder.Configuration["MySQLConnection:MySQLConnectionString"];
builder.Services.AddDbContext<MySQLContext>(options => options.UseMySql(connection, ServerVersion.AutoDetect(connection)));

// Add services to the container.
builder.Services.AddScoped<IPersonService, PersonServiceImplementation>();
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
