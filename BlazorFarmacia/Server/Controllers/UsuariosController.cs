using AutoMapper;
using AutoMapper.QueryableExtensions;
using BlazorFarmacia.Server.Model;
using BlazorFarmacia.Server.Model.Entities;
using BlazorFarmacia.Shared.DTOS.Clientes;
using BlazorFarmacia.Shared.DTOS.Usuarios;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlazorFarmacia.Server.Controllers
{
    [ApiController, Route("api/Usuarios")]
    public class UsuariosController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public UsuariosController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<UsuarioDto>>> Get()
        {
            return await context.Usuarios.ProjectTo<UsuarioDto>(mapper.ConfigurationProvider).ToListAsync();

        }

        [HttpGet("{id:int}")]

        public async Task<ActionResult<UsuarioDto>> Get(int id)
        {
            var usuario = await context.Usuarios.FirstOrDefaultAsync(x => x.Id == id);

            if (usuario == null)
            {
                return NotFound();
            }

            var usuarioDto = new UsuarioDto();
            usuarioDto.Id = usuario.Id;
            usuarioDto.NombreUsuario = usuarioDto.NombreUsuario;


            return usuarioDto;
        }

        [HttpPost]
        public async Task<ActionResult> Add([FromBody] UsuarioDto usuarioDto)
        {
            var usuario = new Usuario();
            usuario.Id = usuarioDto.Id;
            usuario.NombreUsuario = usuarioDto.NombreUsuario;
            usuario.Contraseña = usuario.Contraseña;

            context.Usuarios.Add(usuario);
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
            var usuarioDb = await context.Usuarios.FirstOrDefaultAsync(x => x.Id == id);

            if (usuarioDb == null)
            {
                return NotFound();
            }

            context.Usuarios.Remove(usuarioDb);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
//NombreUsuario y Contraseña