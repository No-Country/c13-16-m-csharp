using System;
using System.Collections.Generic;
using API_Services.Models;
using Microsoft.EntityFrameworkCore;

namespace API_Services.DAL.DataContext;

public partial class AppserviceContext : DbContext
{
    public AppserviceContext()
    {
    }

    public AppserviceContext(DbContextOptions<AppserviceContext> options)
        : base(options)
    {

    }

    public virtual DbSet<Categoria> Categorias { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<DatosBasico> DatosBasicos { get; set; }

    public virtual DbSet<HistorialCliente> HistorialClientes { get; set; }

    public virtual DbSet<HistorialProveedore> HistorialProveedores { get; set; }

    public virtual DbSet<Monedum> Moneda { get; set; }

    public virtual DbSet<Pedido> Pedidos { get; set; }

    public virtual DbSet<PedidoDetalle> PedidoDetalles { get; set; }

    public virtual DbSet<PefilNegocio> PefilNegocios { get; set; }

    public virtual DbSet<Proveedore> Proveedores { get; set; }

    public virtual DbSet<Rol> Rols { get; set; }

    public virtual DbSet<Servicio> Servicios { get; set; }

    public virtual DbSet<Tasa> Tasas { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
        /*#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                => optionsBuilder.UseSqlServer("");*/
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Categoria>(entity =>
        {
            entity.HasKey(e => e.IdCategoria);

            entity.ToTable("categorias");

            entity.Property(e => e.IdCategoria).HasColumnName("id_categoria");
            entity.Property(e => e.Categoria1)
                .HasMaxLength(60)
                .IsFixedLength()
                .HasColumnName("categoria");
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.IdCliente);

            entity.ToTable("clientes");

            entity.Property(e => e.IdCliente).HasColumnName("id_cliente");
            entity.Property(e => e.IdDatos).HasColumnName("id_datos");
            entity.Property(e => e.Saldos)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("saldos");

            entity.HasOne(d => d.IdDatosNavigation).WithMany(p => p.Clientes)
                .HasForeignKey(d => d.IdDatos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_clientes_datos_basicos");
        });

        modelBuilder.Entity<DatosBasico>(entity =>
        {
            entity.HasKey(e => e.IdDatos);

            entity.ToTable("datos_basicos");

            entity.Property(e => e.IdDatos).HasColumnName("id_datos");
            entity.Property(e => e.Apellidos)
                .HasMaxLength(60)
                .IsFixedLength()
                .HasColumnName("apellidos");
            entity.Property(e => e.Calificacion)
                .HasMaxLength(1)
                .IsFixedLength()
                .HasColumnName("calificacion");
            entity.Property(e => e.Celular)
                .HasMaxLength(17)
                .IsFixedLength();
            entity.Property(e => e.IdPerfil).HasColumnName("id_perfil");
            entity.Property(e => e.IdUsuarios).HasColumnName("id_usuarios");
            entity.Property(e => e.Idnacional)
                .HasMaxLength(20)
                .IsFixedLength()
                .HasColumnName("IDnacional");
            entity.Property(e => e.Nombres)
                .HasMaxLength(60)
                .IsFixedLength()
                .HasColumnName("nombres");
            entity.Property(e => e.Referidos)
                .HasMaxLength(50)
                .HasColumnName("referidos");
            entity.Property(e => e.TelfLocal)
                .HasMaxLength(17)
                .IsFixedLength()
                .HasColumnName("Telf_local");

            entity.HasOne(d => d.IdPerfilNavigation).WithMany(p => p.DatosBasicos)
                .HasForeignKey(d => d.IdPerfil)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_datos_basicos_pefil_negocios");

            entity.HasOne(d => d.IdUsuariosNavigation).WithMany(p => p.DatosBasicos)
                .HasForeignKey(d => d.IdUsuarios)
                .HasConstraintName("FK_datos_basicos_usuario");
        });

        modelBuilder.Entity<HistorialCliente>(entity =>
        {
            entity.HasKey(e => e.IdHistorial);

            entity.ToTable("historial_cliente");

            entity.Property(e => e.IdHistorial).HasColumnName("Id_historial");
            entity.Property(e => e.Fecha)
                .HasColumnType("datetime")
                .HasColumnName("fecha");
            entity.Property(e => e.IdCliente).HasColumnName("id_cliente");
            entity.Property(e => e.IdPedido).HasColumnName("id_pedido");
            entity.Property(e => e.Monto)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("monto");
            entity.Property(e => e.Renglon).HasColumnName("renglon");
            entity.Property(e => e.Saldo)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("saldo");
        });

        modelBuilder.Entity<HistorialProveedore>(entity =>
        {
            entity.HasKey(e => e.IdHistorialProveedor);

            entity.ToTable("historial_proveedores");

            entity.Property(e => e.IdHistorialProveedor).HasColumnName("Id_historial_proveedor");
            entity.Property(e => e.Fecha)
                .HasColumnType("datetime")
                .HasColumnName("fecha");
            entity.Property(e => e.IdPedido).HasColumnName("id_pedido");
            entity.Property(e => e.IdProveedores).HasColumnName("id_proveedores");
            entity.Property(e => e.Monto)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("monto");
            entity.Property(e => e.Renglon).HasColumnName("renglon");
            entity.Property(e => e.Saldo)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("saldo");
        });

        modelBuilder.Entity<Monedum>(entity =>
        {
            entity.HasKey(e => e.IdMoneda);

            entity.ToTable("moneda");

            entity.Property(e => e.IdMoneda).HasColumnName("id_moneda");
            entity.Property(e => e.Moneda)
                .HasMaxLength(20)
                .IsFixedLength()
                .HasColumnName("moneda");
        });

        modelBuilder.Entity<Pedido>(entity =>
        {
            entity.HasKey(e => e.IdPedido);

            entity.ToTable("pedidos");

            entity.Property(e => e.IdPedido).HasColumnName("id_pedido");
            entity.Property(e => e.Asignado)
                .HasMaxLength(1)
                .IsFixedLength()
                .HasColumnName("asignado");
            entity.Property(e => e.FechaAsignacion)
                .HasColumnType("datetime")
                .HasColumnName("fecha_asignacion");
            entity.Property(e => e.FechaSolicitud)
                .HasColumnType("datetime")
                .HasColumnName("fecha_solicitud");
            entity.Property(e => e.IdCliente).HasColumnName("id_cliente");
            entity.Property(e => e.IdMoneda).HasColumnName("id_moneda");
            entity.Property(e => e.IdPerfil).HasColumnName("id_perfil");
            entity.Property(e => e.IdProveedores).HasColumnName("id_proveedores");
            entity.Property(e => e.IdTasa).HasColumnName("id_tasa");
            entity.Property(e => e.TotalServicios)
                .HasColumnType("numeric(18, 2)")
                .HasColumnName("total_servicios");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.Pedidos)
                .HasForeignKey(d => d.IdCliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_pedidos_clientes");

            entity.HasOne(d => d.IdMonedaNavigation).WithMany(p => p.Pedidos)
                .HasForeignKey(d => d.IdMoneda)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_pedidos_moneda");

            entity.HasOne(d => d.IdPerfilNavigation).WithMany(p => p.Pedidos)
                .HasForeignKey(d => d.IdPerfil)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_pedidos_pefil_negocios");

            entity.HasOne(d => d.IdProveedoresNavigation).WithMany(p => p.Pedidos)
                .HasForeignKey(d => d.IdProveedores)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_pedidos_proveedores");

            entity.HasOne(d => d.IdTasaNavigation).WithMany(p => p.Pedidos)
                .HasForeignKey(d => d.IdTasa)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_pedidos_tasa");
        });

        modelBuilder.Entity<PedidoDetalle>(entity =>
        {
            entity.HasKey(e => e.IdPedidoDetalle);

            entity.ToTable("pedido_detalle");

            entity.Property(e => e.IdPedidoDetalle).HasColumnName("id_pedido_detalle");
            entity.Property(e => e.Cantidad).HasColumnName("cantidad");
            entity.Property(e => e.Comentario).HasColumnName("comentario");
            entity.Property(e => e.IdPedido).HasColumnName("id_pedido");
            entity.Property(e => e.IdServicios).HasColumnName("id_servicios");
            entity.Property(e => e.Precio)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("precio");
            entity.Property(e => e.Renglon).HasColumnName("renglon");
            entity.Property(e => e.TotalRenglon)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("total_renglon");

            entity.HasOne(d => d.IdPedidoNavigation).WithMany(p => p.PedidoDetalles)
                .HasForeignKey(d => d.IdPedido)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_pedido_detalle_pedidos");

            entity.HasOne(d => d.IdServiciosNavigation).WithMany(p => p.PedidoDetalles)
                .HasForeignKey(d => d.IdServicios)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_pedido_detalle_servicios");
        });

        modelBuilder.Entity<PefilNegocio>(entity =>
        {
            entity.HasKey(e => e.IdPerfil);

            entity.ToTable("pefil_negocios");

            entity.Property(e => e.IdPerfil).HasColumnName("id_perfil");
            entity.Property(e => e.NombrePrefil)
                .HasMaxLength(40)
                .IsFixedLength()
                .HasColumnName("nombre_prefil");
        });

        modelBuilder.Entity<Proveedore>(entity =>
        {
            entity.HasKey(e => e.IdProveedores);

            entity.ToTable("proveedores");

            entity.Property(e => e.IdProveedores).HasColumnName("id_proveedores");
            entity.Property(e => e.IdDatos).HasColumnName("id_datos");
            entity.Property(e => e.Saldos)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("saldos");

            entity.HasOne(d => d.IdDatosNavigation).WithMany(p => p.Proveedores)
                .HasForeignKey(d => d.IdDatos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_proveedores_datos_basicos");
        });

        modelBuilder.Entity<Rol>(entity =>
        {
            entity.HasKey(e => e.IdRol);

            entity.ToTable("Rol");

            entity.Property(e => e.IdRol).HasColumnName("idRol");
            entity.Property(e => e.Roles)
                .HasMaxLength(60)
                .IsFixedLength();
        });

        modelBuilder.Entity<Servicio>(entity =>
        {
            entity.HasKey(e => e.IdServicio);

            entity.ToTable("servicios");

            entity.Property(e => e.IdServicio).HasColumnName("id_servicio");
            entity.Property(e => e.Costo)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("costo");
            entity.Property(e => e.IdCategoria).HasColumnName("id_categoria");
            entity.Property(e => e.IdPerfil).HasColumnName("id_perfil");
            entity.Property(e => e.Precio)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("precio");
            entity.Property(e => e.Servicio1)
                .HasMaxLength(60)
                .IsFixedLength()
                .HasColumnName("servicio");

            entity.HasOne(d => d.IdCategoriaNavigation).WithMany(p => p.Servicios)
                .HasForeignKey(d => d.IdCategoria)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_servicios_categorias");

            entity.HasOne(d => d.IdPerfilNavigation).WithMany(p => p.Servicios)
                .HasForeignKey(d => d.IdPerfil)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_servicios_pefil_negocios");
        });

        modelBuilder.Entity<Tasa>(entity =>
        {
            entity.HasKey(e => e.IdTasa);

            entity.ToTable("tasa");

            entity.Property(e => e.IdTasa).HasColumnName("id_tasa");
            entity.Property(e => e.Fecha)
                .HasColumnType("datetime")
                .HasColumnName("fecha");
            entity.Property(e => e.IdMoneda).HasColumnName("id_moneda");
            entity.Property(e => e.Valor)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("valor");

            entity.HasOne(d => d.IdMonedaNavigation).WithMany(p => p.Tasas)
                .HasForeignKey(d => d.IdMoneda)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tasa_moneda");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuarios);

            entity.ToTable("usuario");

            entity.Property(e => e.IdUsuarios).HasColumnName("id_usuarios");
            entity.Property(e => e.Clave)
                .HasMaxLength(20)
                .IsFixedLength()
                .HasColumnName("clave");
            entity.Property(e => e.Correo)
                .HasMaxLength(60)
                .IsFixedLength()
                .HasColumnName("correo");
            entity.Property(e => e.Estado)
                .HasMaxLength(1)
                .IsFixedLength()
                .HasColumnName("estado");
            entity.Property(e => e.IdRol).HasColumnName("idRol");
            entity.Property(e => e.NombreUsuario)
                .HasMaxLength(40)
                .IsFixedLength()
                .HasColumnName("nombre_usuario");
            entity.Property(e => e.Token)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("token");

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdRol)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_usuario_Rol");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
