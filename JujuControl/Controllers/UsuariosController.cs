using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JujuControl.Data;
using JujuControl.Data.Models.dbModels;
using JujuControl.Business.Services;

namespace JujuControl.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly UsuarioService _usuario;

        public UsuariosController(UsuarioService usuario)
        {
            _usuario = usuario;
        }

        // GET: api/Usuarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuario()
        {

            return await _usuario.GetAllUsuarioAsync();

        }

        // GET: api/Usuarios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> GetUsuario(int id)
        {
            var usuario = await _usuario.GetUsuarioAsync(id);

            if (usuario == null)
            {
                return NotFound();
            }

            return usuario;
        }

        // PUT: api/Usuarios/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuario(int id, Usuario usuario)
        {
            if (id != usuario.Id)
                return BadRequest();

            if (await _usuario.CRUD(usuario, 1))
                return CreatedAtAction("GetUsuario", new { id = usuario.Id }, usuario);

            return NotFound();
        }

        // POST: api/Usuarios
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Usuario>> PostUsuario(Usuario usuario)
        {
            if (await _usuario.CRUD(usuario, 0))
                return CreatedAtAction("GetUsuario", new { id = usuario.Id }, usuario);

            return BadRequest();
        }

        // DELETE: api/Usuarios/5
        [HttpDelete("{id}")]
        public async Task<bool> DeleteUsuario(Usuario usuario)
        {
            return await _usuario.CRUD(usuario, 2);

        }
    }
}
