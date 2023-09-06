using Microsoft.EntityFrameworkCore;
using API_Services.DAL.DataContext;
using API_Services.DAL.Repository;
using API_Services.Models;
using API_Services.BLL.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppserviceContext>(opciones => {
    opciones.UseSqlServer(builder.Configuration.GetConnectionString("Cadena_SQL"));
});

//Inyeccion de Dependencia
//ROL
builder.Services.AddScoped<IGenericRepository<Rol>, RolRepository>();
builder.Services.AddScoped<IRolService, RolService>();
//Perfil de Negocio
builder.Services.AddScoped<IGenericRepository<PerfilNegocio>, PerfilNegocioRepository>();
builder.Services.AddScoped<IPerfilNegocioService, PerfilNegocioService>();
//Datos Basicos
builder.Services.AddScoped<IGenericRepository<DatosBasico>, DatosBasicoRepository>();
builder.Services.AddScoped<IDatosBasicoService, DatosBasicoService>();
//Usuarios
builder.Services.AddScoped<IGenericRepository<DatosBasico>, DatosBasicoRepository>();
builder.Services.AddScoped<IDatosBasicoService, DatosBasicoService>();




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
