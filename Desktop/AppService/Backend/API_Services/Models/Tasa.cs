using System;
using System.Collections.Generic;

namespace API_Services.Models;

public partial class Tasa
{
    public int IdTasa { get; set; }

    public int IdMoneda { get; set; }

    public DateTime? Fecha { get; set; }

    public decimal? Valor { get; set; }

    public virtual Monedum IdMonedaNavigation { get; set; } = null!;

    public virtual ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();
}
