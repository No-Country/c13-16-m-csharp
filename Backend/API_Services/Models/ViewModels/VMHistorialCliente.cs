namespace API_Services.Models.ViewModels
{
    public class VMHistorialCliente
    {
        public int IdHistorial { get; set; }

        public int Renglon { get; set; }

        public int IdCliente { get; set; }

        public int IdPedido { get; set; }

        public decimal? Monto { get; set; }

        public decimal? Saldo { get; set; }

        public string? Fecha { get; set; }
    }
}
