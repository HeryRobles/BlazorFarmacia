using AutoMapper;
using AutoMapper.QueryableExtensions;
using BlazorFarmacia.Server.Model;
using BlazorFarmacia.Server.Model.Entities;
using BlazorFarmacia.Shared.DTOS.Clientes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace BlazorFarmacia.Server.Controllers
{
    [ApiController, Route("api/Clientes")]
    public class ClientesController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public ClientesController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<ClienteDto>>> Get()
        {
            return await context.Clientes.ProjectTo<ClienteDto>(mapper.ConfigurationProvider).ToListAsync();
            
        }

        [HttpGet("{id:int}")]

        public async Task<ActionResult<ClienteDto>> Get(int id)
        {
            var cliente = await context.Clientes.FirstOrDefaultAsync(x => x.Id == id);

            if (cliente == null)
            {
                return NotFound();
            }

            var clienteDto = new ClienteDto();
            clienteDto.Id = cliente.Id;
            clienteDto.Nombre = cliente.Nombre;


            return clienteDto;
        }

        [HttpPost]
        public async Task<ActionResult> Add([FromBody] ClienteDto clienteDto)
        {
            var cliente = new Cliente();
            cliente.Nombre = clienteDto.Nombre;

            context.Clientes.Add(cliente);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> Edit([FromBody] ClienteDto clientesDto)
        {
            var clienteDb = await context.Clientes.FirstOrDefaultAsync(x => x.Id == clientesDto.Id);

            if (clienteDb == null)
            {
                return NotFound();
            }

            clienteDb.Nombre = clienteDb.Nombre;

            context.Clientes.Update(clienteDb);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var clienteDb = await context.Clientes.FirstOrDefaultAsync(x => x.Id == id);

            if (clienteDb == null)
            {
                return NotFound();
            }

            context.Clientes.Remove(clienteDb);
            await context.SaveChangesAsync();
            return Ok();
        }

    }

}
