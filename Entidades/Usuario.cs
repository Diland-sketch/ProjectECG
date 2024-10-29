using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Usuario
    {

        public string NombreUsuario { get; set; }
        public string contrasenha;
        public Rol Rol { get; private set; }

        public Usuario(string nombreUsuario, string contrasenha, Rol rol)
        {
            NombreUsuario = nombreUsuario;
            this.contrasenha = contrasenha;
            Rol = rol;
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
            return $"{base.ToString()}, Usuario: {NombreUsuario}, Rol: {Rol.NombreRol}";
        }

    }
}
