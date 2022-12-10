namespace BlazorFarmacia.Server.Model.Entities
{
    public class Usuario
    {
        public int Id { get; set; }
        public string NombreUsuario { get; set; }
        public string Contraseña { get; set; }

        public List<Empleado> Empleados { get; set; }

    }
}
