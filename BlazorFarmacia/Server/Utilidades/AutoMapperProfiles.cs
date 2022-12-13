using AutoMapper;
using BlazorFarmacia.Server.Model.Entities;
using BlazorFarmacia.Shared.DTOS.Clientes;
using BlazorFarmacia.Shared.DTOS.Empleados;
using BlazorFarmacia.Shared.DTOS.LotesProductos;
using BlazorFarmacia.Shared.DTOS.Productos;
using BlazorFarmacia.Shared.DTOS.TarjetasPuntos;
using BlazorFarmacia.Shared.DTOS.Usuarios;
using BlazorFarmacia.Shared.DTOS.Ventas;

namespace BlazorFarmacia.Server.Utilidades
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Cliente, ClienteDto>();
            CreateMap<Producto, ProductoDto>();
            CreateMap<Empleado, EmpleadoDto>();
            CreateMap<LoteProducto, LoteProductoDto>();
            CreateMap<TarjetaPuntos, TarjetaPuntosDto>();
            CreateMap<Usuario, UsuarioDto>();
            CreateMap<Venta, VentaDto>();
        }
    }
}
