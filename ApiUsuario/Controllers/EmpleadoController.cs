using Microsoft.AspNetCore.Mvc;
using ApiUsuario.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using ApiUsuario.Models;

namespace ApiUsuario.Controllers
{
    [ApiController]
    [Route("api/empleados")]
    public class EmpleadoController : ControllerBase
    {
        private readonly ManejoUsuariosContext context;

        public EmpleadoController(ManejoUsuariosContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<Empleado>> Get()
        {

            var empleados = await context.Empleados
                .ToListAsync();
            return empleados;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult> GetConId(int id)
        {
            var empleadoDb = await context.Empleados
                                    .FirstOrDefaultAsync(e => e.Id == id);
            if (empleadoDb is null)
            {
                return NotFound();
            }
            return Ok(empleadoDb);
        }


        [HttpGet("{codigoEmpleado}")]
        public async Task<ActionResult<Empleado>> Get(string codigoEmpleado)
        {
            var usuario = await context.Empleados.Where(e => e.CodigoEmpleado == codigoEmpleado).FirstOrDefaultAsync();
            if (usuario is not null)
            {
                return usuario;
            }
            else
            {
                return new Empleado();
            }
        }

        [HttpPost]
        public async Task<ActionResult> Post(Empleado empleado)
        {
            Empleado nuevoEmpleado = new Empleado
            {
                CodigoEmpleado = empleado.CodigoEmpleado,
                Pais = empleado.Pais,
                Titulo = empleado.Titulo,
                PrimerNombre = empleado.PrimerNombre,
                SegundoNombre = empleado.SegundoNombre,
                PrimerApellido = empleado.PrimerApellido,
                SegundoApellido = empleado.SegundoApellido,
                Email = empleado.Email,
                FechaNacimiento = empleado.FechaNacimiento,
                TelefonoMovil = empleado.TelefonoMovil,
            };
            context.Add(nuevoEmpleado);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> Put(Empleado empleado)
        {
            var existe = await context.Empleados.FirstOrDefaultAsync(e => e.CodigoEmpleado == empleado.CodigoEmpleado);
            if (existe is null)
            {
                return NotFound();
            }
            existe.CodigoEmpleado = empleado.CodigoEmpleado;
            existe.Pais = empleado.Pais;
            existe.Titulo = empleado.Titulo;
            existe.PrimerNombre = empleado.PrimerNombre;
            existe.SegundoNombre = empleado.SegundoNombre;
            existe.Email = empleado.Email;
            existe.FechaNacimiento = empleado.FechaNacimiento;
            existe.TelefonoMovil = empleado.TelefonoMovil;
            context.Update(existe);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var empleado = await context.Empleados.FirstOrDefaultAsync(e => e.Id == id);
            if (empleado is null)
            {
                return NotFound();
            }
            context.Remove(empleado);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
