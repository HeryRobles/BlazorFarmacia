using AutoMapper;
using AutoMapper.QueryableExtensions;
using BlazorFarmacia.Server.Model;
using BlazorFarmacia.Server.Model.Entities;
using BlazorFarmacia.Shared.DTOS.Empleados;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace BlazorFarmacia.Server.Controllers
{
    [ApiController, Route("api/Empleados")]
    public class EmpleadosController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public EmpleadosController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;   
        }
        [HttpGet]

        public async Task<ActionResult<List<EmpleadoDto>>> Get()
        {
            return await context.Empleados.ProjectTo<EmpleadoDto>(mapper.ConfigurationProvider).ToListAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<EmpleadoDto >> Get(int id)
        {
            var empleado = await context.Empleados.FirstOrDefaultAsync(x => x.Id == id);

            if (empleado == null)
            {
                return NotFound();
            }

            var empleadoDto = new EmpleadoDto();
            empleadoDto.Id = empleado.Id;
            empleadoDto.Nombre = empleado.Nombre;


            return empleadoDto;
        }

        [HttpPost]
        public async Task<ActionResult> Add([FromBody] EmpleadoDto empleadoDto)
        {
            var empleado = new Empleado(); 
            empleado.Nombre = empleadoDto.Nombre;

            context.Empleados.Add(empleado);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> Edit([FromBody] EmpleadoDto empleadosDto)
        {
            var empleadoDb = await context.Empleados.FirstOrDefaultAsync(x => x.Id == empleadosDto.Id);

            if (empleadoDb == null)
            {
                return NotFound();
            }

            empleadoDb.Nombre = empleadoDb.Nombre;

            context.Empleados.Update(empleadoDb);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var empleadoDb = await context.Empleados.FirstOrDefaultAsync(x => x.Id == id);

            if (empleadoDb == null)
            {
                return NotFound();
            }

            context.Empleados.Remove(empleadoDb);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
