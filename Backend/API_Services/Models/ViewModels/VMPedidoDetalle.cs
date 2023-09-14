namespace API_Services.Models.ViewModels
{
    public class VMPedidoDetalle
    {
        public int Renglon { get; set; }

        public int IdPedidoDetalle { get; set; }

        public int IdPedido { get; set; }

        public int IdServicios { get; set; }

        public int Cantidad { get; set; }

        public decimal? Precio { get; set; }

        public decimal? TotalRenglon { get; set; }

        public string? Comentario { get; set; }
    }
}
