using System;
using System.Collections.Generic;

namespace API_Services.Models;

public partial class Rol
{
    public int IdRol { get; set; }

    public string? Roles { get; set; }

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
