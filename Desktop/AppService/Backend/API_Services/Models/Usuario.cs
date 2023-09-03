using System;
using System.Collections.Generic;

namespace API_Services.Models;

public partial class Usuario
{
    public int IdUsuarios { get; set; }

    public int IdRol { get; set; }

    public string NombreUsuario { get; set; } = null!;

    public string? Clave { get; set; }

    public string? Token { get; set; }

    public string Estado { get; set; } = null!;

    public string Correo { get; set; } = null!;

    public virtual ICollection<DatosBasico> DatosBasicos { get; set; } = new List<DatosBasico>();

    public virtual Rol IdRolNavigation { get; set; } = null!;
}
