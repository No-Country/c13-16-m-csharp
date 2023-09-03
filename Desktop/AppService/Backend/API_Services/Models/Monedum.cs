using System;
using System.Collections.Generic;

namespace API_Services.Models;

public partial class Monedum
{
    public int IdMoneda { get; set; }

    public string Moneda { get; set; } = null!;

    public virtual ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();

    public virtual ICollection<Tasa> Tasas { get; set; } = new List<Tasa>();
}
