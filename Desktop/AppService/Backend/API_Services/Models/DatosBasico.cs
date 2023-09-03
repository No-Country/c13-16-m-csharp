using System;
using System.Collections.Generic;

namespace API_Services.Models;

public partial class DatosBasico
{
    public int IdDatos { get; set; }

    public int IdPerfil { get; set; }

    public int? IdUsuarios { get; set; }

    public string? Nombres { get; set; }

    public string? Apellidos { get; set; }

    public string? Idnacional { get; set; }

    public string? Direccion { get; set; }

    public string? Celular { get; set; }

    public string? TelfLocal { get; set; }

    public string? Referidos { get; set; }

    public string? Calificacion { get; set; }

    public virtual ICollection<Cliente> Clientes { get; set; } = new List<Cliente>();

    public virtual PerfilNegocio IdPerfilNavigation { get; set; } = null!;

    public virtual Usuario? IdUsuariosNavigation { get; set; }

    public virtual ICollection<Proveedore> Proveedores { get; set; } = new List<Proveedore>();
}
