using Microsoft.EntityFrameworkCore;
using webapi;
using webapi.Services;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

/*
*Se crea la conexion con SQLServer y se pasa la configuracion del servidor desde el archivo appsetting.
*/
builder.Services.AddSqlServer<TareasContext>(builder.Configuration.GetConnectionString("cnTareas"));

//inyectamos la dependica de la clase HelloWordSerivce

builder.Services.AddScoped<IHelloWorldService, HelloWorldService>(); 
builder.Services.AddScoped<ICategoriaService, CategoriaService>(); 
builder.Services.AddScoped<ITareaService, TareaService>(); 


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

//Middleware para pagina de inicio por defecto
//app.UseWelcomePage();



//Middleware custom para la fecha del servidor
//app.UseTimeMiddleware();

app.MapControllers();

app.Run();
