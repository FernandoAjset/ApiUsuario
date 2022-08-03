using ApiUsuario.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace ApiUsuario.Controllers
{
    [Route("api/usuarios")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly ManejoUsuariosContext context;

        public UsuarioController(ManejoUsuariosContext context)
        {
            this.context = context;
        }

        [HttpGet("{nombreUsuario}")]
        public async Task<ActionResult<Usuario>> Get(string nombreUsuario)
        {
            var usuario = await context.Usuarios.Where(u => u.NombreUsuario == nombreUsuario).FirstOrDefaultAsync();
            if (usuario is not null)
            {
                return usuario;
            }
            else
            {
                return new Usuario();
            }
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(Usuario usuario)
        {
            Usuario nuevoUsuario = new Usuario
            {
                NombreUsuario = usuario.NombreUsuario,
                Contrasenia = usuario.Contrasenia,
            };
            context.Add(nuevoUsuario);
            await context.SaveChangesAsync();
            return nuevoUsuario.Id;
        }
    }
}
