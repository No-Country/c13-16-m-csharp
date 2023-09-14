namespace API_Services.Models.ViewModels
{
    public class VMPedido
    {
        public int IdPedido { get; set; }

        public int IdCliente { get; set; }

        public int IdPerfil { get; set; }

        public string? FechaSolicitud { get; set; }

        public string? FechaAsignacion { get; set; }

        public int IdMoneda { get; set; }

        public int IdTasa { get; set; }

        public int IdProveedores { get; set; }

        public decimal? TotalServicios { get; set; }

        public string? Asignado { get; set; }

    }
}
