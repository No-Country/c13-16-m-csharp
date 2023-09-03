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

<<<<<<< HEAD
    public virtual PefilNegocio IdPerfilNavigation { get; set; } = null!;
=======
    public virtual PerfilNegocio IdPerfilNavigation { get; set; } = null!;
>>>>>>> ce1e7770fd9080525efd70136e5209fda6c6469f

    public virtual Usuario? IdUsuariosNavigation { get; set; }

    public virtual ICollection<Proveedore> Proveedores { get; set; } = new List<Proveedore>();
}
