using System;

namespace API_Services.Models.ViewModels
{
    public class VMServicio
    {
        public int IdServicio { get; set; }
        public int IdPerfil { get; set; }
        public int IdCategoria { get; set; }
        public string Servicio1 { get; set; }
        public decimal? Precio { get; set; }
        public decimal? Costo { get; set; }
        public string CategoriaNombre { get; set; } 
    }
}
