namespace BlazorFarmacia.Server.Model.Entities
{
    public class Producto
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public decimal ValorUnitario { get; set; }
        public string UbicacionProducto { get; set; }

        public List<LoteProducto> LoteProductos { get; set; }

    }
}
