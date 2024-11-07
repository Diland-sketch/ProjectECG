using Persistencia;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class ServiceUser
    {
        private UserRepository userRepository;

        public ServiceUser()
        {
            userRepository = new UserRepository();
        }

        public string Guardar(Usuario user)
        {
            return userRepository.Guardar(user);
        }

        public bool Login(Usuario usuario)
        {
            return userRepository.ValidarUsuarioAdmin(usuario);
        }
    }
}
