using Microsoft.AspNetCore.Http;
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
//proveedor
builder.Services.AddScoped<IGenericRepository<Proveedore>, ProveedoreRepository>();
builder.Services.AddScoped<IProveedoreService, ProveedoreService>();
//Historial Cliente
builder.Services.AddScoped<IGenericRepository<HistorialCliente>, HistorialClienteRepository>();
builder.Services.AddScoped<IHistorialClienteService, HistorialClienteService>();
// Historia Proveedor
builder.Services.AddScoped<IGenericRepository<HistorialProveedore>, HistorialProveedoreRepository>();
builder.Services.AddScoped<IHistorialProveedoreService, HistorialProveedoreService>();
//pedido
builder.Services.AddScoped<IGenericRepository<Pedido>, PedidoRepository>();
builder.Services.AddScoped<IPedidoService, PedidoService>();
//pedido Detalle
builder.Services.AddScoped<IGenericRepository<PedidoDetalle>, PedidoDetalleRepository>();
builder.Services.AddScoped<IPedidoDetalleService, PedidoDetalleService>();
//
var app = builder.Build();

// Configure the HTTP request pipeline.
/*if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}*/

app.UseSwagger();
app.UseSwaggerUI();



app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();




