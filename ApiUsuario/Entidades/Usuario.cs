using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace ApiUsuario.Entidades
{
    public partial class Usuario
    {
        public int Id { get; set; }
        public string NombreUsuario { get; set; }
        public string Contrasenia { get; set; }
    }
}
