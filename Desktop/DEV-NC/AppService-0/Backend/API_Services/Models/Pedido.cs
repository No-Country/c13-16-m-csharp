using System;
using System.Collections.Generic;

namespace API_Services.Models;

public partial class Pedido
{
    public int IdPedido { get; set; }

    public int IdCliente { get; set; }

    public int IdPerfil { get; set; }

    public DateTime FechaSolicitud { get; set; }

    public DateTime FechaAsignacion { get; set; }

    public int IdMoneda { get; set; }

    public int IdTasa { get; set; }

    public int IdProveedores { get; set; }

    public decimal? TotalServicios { get; set; }

    public string? Asignado { get; set; }

    public virtual Cliente IdClienteNavigation { get; set; } = null!;

    public virtual Monedum IdMonedaNavigation { get; set; } = null!;

    public virtual PefilNegocio IdPerfilNavigation { get; set; } = null!;

    public virtual Proveedore IdProveedoresNavigation { get; set; } = null!;

    public virtual Tasa IdTasaNavigation { get; set; } = null!;

    public virtual ICollection<PedidoDetalle> PedidoDetalles { get; set; } = new List<PedidoDetalle>();
}
