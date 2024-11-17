using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string NombreUsuario { get; set; }
        public string contrasenha;
        public int IdRol { get; set; }

        public Usuario(int idUsuario, string nombreUsuario, string contrasenha, int rol)
        {
            IdUsuario = idUsuario;
            NombreUsuario = nombreUsuario;
            this.contrasenha = contrasenha;
            IdRol = rol;
        }

        public Usuario()
        {
        }

        public bool ValidarCredenciales(string nombreUsuario, string contrasenha)
        {
            return NombreUsuario.Equals(nombreUsuario) && this.contrasenha.Equals(contrasenha);
        }

        public override string ToString()
        {
            return $"{base.ToString()}, Usuario: {NombreUsuario}, Rol: {IdRol}";
        }

    }
}
