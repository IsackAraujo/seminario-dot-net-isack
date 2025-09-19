using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PW45S.Models;
using PW45S.Repositories.Interfaces;

namespace PW45S.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        public UsuarioController(IUsuarioRepositorio usuarioRepositorio) { 
            _usuarioRepositorio = usuarioRepositorio;

        }

        [HttpGet]
        public async Task<ActionResult<List<UsuarioModel>>> getAll()
        {
            List<UsuarioModel> usuarios = await _usuarioRepositorio.BuscarTodosUsuarios();
            return Ok(usuarios);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioModel>> getById(int id)
        {
            UsuarioModel usuario = await _usuarioRepositorio.BuscarPorId(id);       
            return Ok(usuario);
        }

        [HttpPost]
        public async Task<ActionResult<UsuarioModel>> create([FromBody] UsuarioModel usuarioModel)
        {
            UsuarioModel usuario = await _usuarioRepositorio.Adicionar(usuarioModel);
            return Ok(usuario);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<UsuarioModel>> delete(int id)
        {
            bool result = await _usuarioRepositorio.Apagar(id);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UsuarioModel>> update([FromBody] UsuarioModel usuarioModel, int id)
        {
            UsuarioModel usuario = await _usuarioRepositorio.Atualizar(usuarioModel, id);
            return Ok(usuario);
        }

    }
}
