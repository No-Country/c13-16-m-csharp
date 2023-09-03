using System;
using System.Collections.Generic;

namespace API_Services.Models;

public partial class PedidoDetalle
{
    public int Renglon { get; set; }

    public int IdPedidoDetalle { get; set; }

    public int IdPedido { get; set; }

    public int IdServicios { get; set; }

    public int Cantidad { get; set; }

    public decimal? Precio { get; set; }

    public decimal? TotalRenglon { get; set; }

    public string? Comentario { get; set; }

    public virtual Pedido IdPedidoNavigation { get; set; } = null!;

    public virtual Servicio IdServiciosNavigation { get; set; } = null!;
}
