namespace BlazorFarmacia.Server.Model.Entities
{
    public class LoteProducto
    {
        public int Id { get; set; }
        public int lote { get; set; }
        public DateTime FechaCaducidad { get; set; }
        public int ProductoId { get; set; }

    }
}
