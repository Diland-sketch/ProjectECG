using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia
{
    public class UserRepository
    {
        public bool ValidarUsuario(Usuario usuario)
        {
            if(usuario.NombreUsuario == "admin" && usuario.contrasenha == "123")
            {
                return true;
            }
            return false;
        }
    }
}
