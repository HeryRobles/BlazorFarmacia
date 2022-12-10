using AutoMapper;
using BlazorFarmacia.Server.Model.Entities;
using BlazorFarmacia.Shared.DTOS.Clientes;


namespace BlazorFarmacia.Server.Utilidades
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Cliente, ClienteDto>();
            //CreateMap<Producto, ProductoDto>();
            //CreateMap<Empleado, EmpleadoDto>();
        }
    }
}
