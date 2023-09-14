namespace API_Services.Models.ViewModels
{
    public class VMHistorialProveedore
    {
        public int IdHistorialProveedor { get; set; }

        public int Renglon { get; set; }

        public int IdProveedores { get; set; }

        public int IdPedido { get; set; }

        public decimal? Monto { get; set; }

        public decimal? Saldo { get; set; }

        public string? Fecha { get; set; }
    }
}
