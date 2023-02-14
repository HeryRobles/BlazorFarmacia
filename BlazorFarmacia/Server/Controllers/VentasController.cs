using AutoMapper;
using AutoMapper.QueryableExtensions;
using BlazorFarmacia.Server.Model;
using BlazorFarmacia.Server.Model.Entities;
using BlazorFarmacia.Shared.DTOS.Ventas;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlazorFarmacia.Server.Controllers
{
    [ApiController, Route("api/Ventas")]
    public class VentasController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;
      

        public VentasController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<VentaDto>>> Get()
        {
            return await context.Ventas.ProjectTo<VentaDto>(mapper.ConfigurationProvider).ToListAsync();
           
        }

        [HttpGet("{id:int}")]

        public async Task<ActionResult<VentaDto>> Get(int id)
        {
            var venta = await context.Ventas.FirstOrDefaultAsync(x => x.Id == id);

            if (venta == null)
            {
                return NotFound();
            }

            var ventaDto = new VentaDto();
            ventaDto.Id = venta.Id;
            ventaDto.Fecha = venta.Fecha;
            ventaDto.TotalVenta = venta.TotalVenta;
            ventaDto.Folio = venta.Folio;

            return ventaDto;
        }

        [HttpPost]
        public async Task<ActionResult> Add([FromBody] VentaDto ventaDto)
        {
            var venta = new Venta();
            venta.Folio = ventaDto.Folio;
            venta.TotalVenta = ventaDto.TotalVenta;

            context.Ventas.Add(venta);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> Edit([FromBody] VentaDto ventasDto)
        {
            var ventasDb = await context.Ventas.FirstOrDefaultAsync(x => x.Id == ventasDto.Id);

            if (ventasDb == null)
            {
                return NotFound();
            }

            ventasDb.TotalVenta = ventasDb.TotalVenta;

            context.Ventas.Update(ventasDb);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var ventasDb = await context.Ventas.FirstOrDefaultAsync(x => x.Id == id);

            if (ventasDb == null)
            {
                return NotFound();
            }

            context.Ventas.Remove(ventasDb);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
