using Api.Models;
using Api.Repositórios.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        public UsuarioController(IUsuarioRepositorio usuarioRepositorio)
        {
           _usuarioRepositorio = usuarioRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<UsuarioModel>>> BuscarUsuarios() {
           List<UsuarioModel> usuarios = await _usuarioRepositorio.BuscarTodosUsuarios();
            return Ok(usuarios);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioModel>> BuscarPorId(int id)
        {
            UsuarioModel usuarios = await _usuarioRepositorio.BuscarPorId(id);
            return Ok(usuarios);
        }
        [HttpPost]
        public async Task<ActionResult<UsuarioModel>> Cadastrar([FromBody] UsuarioModel usuario)
        {
           UsuarioModel user =  await _usuarioRepositorio.Adicionar(usuario);
            return Ok(user);
        }
        [HttpDelete] 
        public async Task <ActionResult> Apagar(int id)
        {
           await _usuarioRepositorio.Apagar(id);
            return Ok("Apagado");
        }
        [HttpPut]
        public async Task<ActionResult<UsuarioModel>> Atualizar([FromBody]UsuarioModel usuario, int id)
        {
            var user = await _usuarioRepositorio.Atualizar(usuario, id);
            return Ok(user);
        }
    }
}
