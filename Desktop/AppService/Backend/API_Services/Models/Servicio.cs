using System;
using System.Collections.Generic;

namespace API_Services.Models;

public partial class Servicio
{
    public int IdServicio { get; set; }

    public int IdPerfil { get; set; }

    public int IdCategoria { get; set; }

    public string Servicio1 { get; set; } = null!;

    public decimal? Precio { get; set; }

    public decimal? Costo { get; set; }

    public virtual Categoria IdCategoriaNavigation { get; set; } = null!;

    public virtual PefillNegocio IdPerfilNavigation { get; set; } = null!;

    public virtual ICollection<PedidoDetalle> PedidoDetalles { get; set; } = new List<PedidoDetalle>();
}
