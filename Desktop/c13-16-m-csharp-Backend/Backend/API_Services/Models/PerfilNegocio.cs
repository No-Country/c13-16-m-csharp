using System;
using System.Collections.Generic;

namespace API_Services.Models;

public partial class PerfilNegocio
{
    public int IdPerfil { get; set; }

    public string? NombrePerfil { get; set; }

    public virtual ICollection<DatosBasico> DatosBasicos { get; set; } = new List<DatosBasico>();

    public virtual ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();

    public virtual ICollection<Servicio> Servicios { get; set; } = new List<Servicio>();
}
