using FormulaOne.DataService.Data;
using FormulaOne.DataService.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.DependencyInjection.ServiceCollection.
//using Microsoft.Extensions.DependencyInjection.Extensions.ServiceCollectionDescriptorExtensions;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//* [13] Get ConnectionString
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

//* Initializing my DbContext inside the DI Container
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlite(connectionString));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//* [17]
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

//* [18] Inicializando el automapper: Busca en todo el assembly por un archivos de configuraci´n de Automaper para utilizarlo en run time.
//builder.Services.AddAutoMapper(typeof(MapperConfig));


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
