namespace API_Services.Models.ViewModels
{
    public class VMUsuario
    {
        public int IdUsuarios { get; set; }

        public int IdRol { get; set; }

        public string NombreUsuario { get; set; } = null!;

        public string? Clave { get; set; }

        public string? Token { get; set; }

        public string Estado { get; set; } = null!;

        public string Correo { get; set; } = null!;

    }
}
