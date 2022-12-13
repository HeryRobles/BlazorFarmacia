using AutoMapper;
using AutoMapper.QueryableExtensions;
using BlazorFarmacia.Server.Model;
using BlazorFarmacia.Server.Model.Entities;
using BlazorFarmacia.Shared.DTOS.LotesProductos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlazorFarmacia.Server.Controllers
{
    [ApiController, Route("api/LotesProductos")]
    public class LotesProductosController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public LotesProductosController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<LoteProductoDto>>> Get()
        {
            return await context.LoteProductos.ProjectTo<LoteProductoDto>(mapper.ConfigurationProvider).ToListAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<LoteProductoDto>> Get(int id)
        {
            var loteProducto = await context.LoteProductos.FirstOrDefaultAsync(x => x.Id == id);

            if (loteProducto == null)
            {
                return NotFound();
            }

            var loteProductoDto = new LoteProductoDto();
            loteProductoDto.Id = loteProducto.Id;
            loteProductoDto.Lote = loteProducto.Lote;
            loteProductoDto.FechaCaducidad = loteProducto.FechaCaducidad;


            return loteProductoDto;
        }

        [HttpPost]
        public async Task<ActionResult> Add([FromBody] LoteProductoDto loteProductoDto)
        {
            var loteProducto = new LoteProducto();
            loteProducto.Id = loteProductoDto.Id;
            loteProducto.Lote = loteProductoDto.Lote;
            loteProducto.FechaCaducidad = loteProductoDto.FechaCaducidad;

            context.LoteProductos.Add(loteProducto);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> Edit([FromBody] LoteProductoDto loteProductoDto)
        {
            var loteProductosDb = await context.LoteProductos.FirstOrDefaultAsync(x => x.Id == loteProductoDto.Id);

            if (loteProductosDb == null)
            {
                return NotFound();
            }

            loteProductosDb.Lote = loteProductosDb.Lote;
            loteProductosDb.FechaCaducidad = loteProductosDb.FechaCaducidad;

            context.LoteProductos.Update(loteProductosDb);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var loteProductosDb = await context.LoteProductos.FirstOrDefaultAsync(x => x.Id == id);

            if (loteProductosDb == null)
            {
                return NotFound();
            }

            context.LoteProductos.Remove(loteProductosDb);
            await context.SaveChangesAsync();
            return Ok();
        }

    }

}

