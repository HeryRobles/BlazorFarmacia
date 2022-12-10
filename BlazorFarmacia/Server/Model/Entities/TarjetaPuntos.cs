namespace BlazorFarmacia.Server.Model.Entities
{
    public class TarjetaPuntos
    {
        public int Id { get; set; }
        public int Folio { get; set; }

        public List<Cliente> Clientes { get; set; }

    }
}
