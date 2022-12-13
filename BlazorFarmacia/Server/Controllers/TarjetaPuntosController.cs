using AutoMapper;
using AutoMapper.QueryableExtensions;
using BlazorFarmacia.Server.Model;
using BlazorFarmacia.Server.Model.Entities;
using BlazorFarmacia.Shared.DTOS.TarjetasPuntos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlazorFarmacia.Server.Controllers
{
    [ApiController, Route("api/TarjetaPuntos")]
    public class TarjetaPuntosController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public TarjetaPuntosController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<TarjetaPuntosDto>>> Get()
        {
            return await context.TarjetasPuntos.ProjectTo<TarjetaPuntosDto>(mapper.ConfigurationProvider).ToListAsync();
            

        }

        
        [HttpGet("{id:int}")]

        public async Task<ActionResult<TarjetaPuntosDto>> Get(int id)
        {
            var tarjeta = await context.TarjetasPuntos.FirstOrDefaultAsync(x => x.Id == id);

            if (tarjeta == null)
            {
                return NotFound();
            }

            var tarjetaDto = new TarjetaPuntosDto();
            tarjetaDto.Id = tarjeta.Id;
            tarjetaDto.Folio = tarjeta.Folio;


            return tarjetaDto;
        }

        [HttpPost]
        public async Task<ActionResult> Add([FromBody] TarjetaPuntosDto tarjetaDto)
        {
            var tarjeta = new TarjetaPuntos();
            tarjeta.Folio = tarjetaDto.Folio;

            context.TarjetasPuntos.Add(tarjeta);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> Edit([FromBody] TarjetaPuntosDto tarjetasDto)
        {
            var tarjetasDb = await context.TarjetasPuntos.FirstOrDefaultAsync(x => x.Id == tarjetasDto.Id);

            if (tarjetasDb == null)
            {
                return NotFound();
            }

            tarjetasDb.Folio = tarjetasDb.Folio;
            tarjetasDb.Id = tarjetasDb.Id;

            context.TarjetasPuntos.Update(tarjetasDb);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var tarjetasDb = await context.TarjetasPuntos.FirstOrDefaultAsync(x => x.Id == id);

            if (tarjetasDb == null)
            {
                return NotFound();
            }

            context.TarjetasPuntos.Remove(tarjetasDb);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
