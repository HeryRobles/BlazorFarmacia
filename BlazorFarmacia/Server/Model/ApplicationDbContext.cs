using BlazorFarmacia.Server.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlazorFarmacia.Server.Model
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options)
            : base(options)
        {

        }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<LoteProducto> LoteProductos { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<TarjetaPuntos> TarjetasPuntos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Venta> Ventas { get; set; }
    }
}
