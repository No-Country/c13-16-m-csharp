using System;
using System.Collections.Generic;

namespace API_Services.Models;

public partial class HistorialProveedore
{
    public int IdHistorialProveedor { get; set; }

    public int Renglon { get; set; }

    public int IdProveedores { get; set; }

    public int IdPedido { get; set; }

    public decimal? Monto { get; set; }

    public decimal? Saldo { get; set; }

    public DateTime? Fecha { get; set; }

    public virtual Pedido IdPedidoNavigation { get; set; } = null!;

    public virtual Proveedore IdProveedoresNavigation { get; set; } = null!;
}
