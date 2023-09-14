namespace API_Services.Models.ViewModels
{
    public class VMProveedore
    {
        public int IdProveedores { get; set; }

        public int IdDatos { get; set; } // Cambiado a int para que coincida con Proveedore

        public decimal? Saldos { get; set; }
    }
}
