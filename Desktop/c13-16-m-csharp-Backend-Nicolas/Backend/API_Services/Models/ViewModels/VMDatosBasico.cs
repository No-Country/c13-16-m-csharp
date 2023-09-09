namespace API_Services.Models.ViewModels
{
    public class VMDatosBasico
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

    }
}
