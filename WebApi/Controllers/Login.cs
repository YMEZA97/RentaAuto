using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Modelos
{
    public class Login
    {
        public string UsuarioId { get; set; }
        public string Nombre { get; set; }
        public string Contrasenia { get; set; }
    }
}
