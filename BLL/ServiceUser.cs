using DAL;
using ENTITY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ServiceUser
    {
        private UserRepository userRepository;

        public ServiceUser()
        {
            userRepository = new UserRepository();
        }

        public bool Login(Usuario usuario)
        {
            return userRepository.ValidarUsuario(usuario);
        }
    }
}
