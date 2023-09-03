using System;
using System.Collections.Generic;

namespace API_Services.Models;

public partial class Proveedore
{
    public int IdProveedores { get; set; }

    public int IdDatos { get; set; }

    public decimal? Saldos { get; set; }

    public virtual DatosBasico IdDatosNavigation { get; set; } = null!;

    public virtual ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();
}
