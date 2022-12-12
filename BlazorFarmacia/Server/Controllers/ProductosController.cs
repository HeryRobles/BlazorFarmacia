using AutoMapper;
using AutoMapper.QueryableExtensions;
using BlazorFarmacia.Server.Model;
using BlazorFarmacia.Server.Model.Entities;
using BlazorFarmacia.Shared.DTOS.Productos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Contracts;

namespace BlazorFarmacia.Server.Controllers
{
    [ApiController, Route("api/Productos")]
    public class ProductosController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public ProductosController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProductoDto>>> Get()
        {
            return await context.Productos.ProjectTo<ProductoDto>(mapper.ConfigurationProvider).ToListAsync();

        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<ProductoDto>> Get(int id)
        {
            var producto = await context.Productos.FirstOrDefaultAsync(x => x.Id == id);

            if (producto == null)
            {
                return NotFound();
            }

            var productoDto = new ProductoDto();
            productoDto.Id = producto.Id;
            productoDto.Descripcion = producto.Descripcion;


            return productoDto;
        }

        [HttpPost]
        public async Task<ActionResult> Add([FromBody] ProductoDto productoDto)
        {
            var producto = new Producto();
            producto.Descripcion = productoDto.Descripcion;

            context.Productos.Add(producto);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> Edit([FromBody] ProductoDto productosDto)
        {
            var productoDb = await context.Productos.FirstOrDefaultAsync(x => x.Id == productosDto.Id);

            if (productoDb == null)
            {
                return NotFound();
            }

            productoDb.Descripcion = productoDb.Descripcion;

            context.Productos.Update(productoDb);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var productoDb = await context.Productos.FirstOrDefaultAsync(x => x.Id == id);

            if (productoDb == null)
            {
                return NotFound();
            }

            context.Productos.Remove(productoDb);
            await context.SaveChangesAsync();
            return Ok();
        }
    }

}
