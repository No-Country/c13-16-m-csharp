using System;
using System.Collections.Generic;

namespace API_Services.Models;

public partial class HistorialCliente
{
    public int IdHistorial { get; set; }

    public int Renglon { get; set; }

    public int IdCliente { get; set; }

    public int IdPedido { get; set; }

    public decimal? Monto { get; set; }

    public decimal? Saldo { get; set; }

    public DateTime? Fecha { get; set; }

    public virtual Cliente IdClienteNavigation { get; set; } = null!;

    public virtual Pedido IdPedidoNavigation { get; set; } = null!;
}
