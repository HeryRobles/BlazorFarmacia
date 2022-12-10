using System.ComponentModel.DataAnnotations;

namespace BlazorFarmacia.Server.Model.Entities
{
    public class Cliente
    {
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; }
        public int TarjetaPuntoId { get; set; }

        public List<Venta> Ventas { get; set; }

    }
}
