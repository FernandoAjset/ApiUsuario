using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace ApiUsuario.Entidades
{
    public partial class Empleado
    {
        [NotMapped]
        public int Id { get; set; }
        public string CodigoEmpleado { get; set; }
        public string Pais { get; set; }
        public string Titulo { get; set; }
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string Email { get; set; }
        public string FechaNacimiento { get; set; }
        public string TelefonoMovil { get; set; }
    }
}
