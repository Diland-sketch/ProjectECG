using Persistencia;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;
using System.Data;


namespace Logica
{
    public class ServiceUser : ICrud<Usuario>
    {
        private UsuarioRepositorio userRepository;
        public ServiceUser()
        {
            userRepository = new UsuarioRepositorio();
        }

        public bool Login(Usuario usuario)
        {
            return userRepository.ValidarUsuario(usuario);
        }
        public string Guardar(Usuario usuario)
        {
            return userRepository.Guardar(usuario);
        }

        public List<Usuario> ConsultarTodo()
        {
            throw new NotImplementedException();
        }

        public string ConsultarId(string id)
        {
            throw new NotImplementedException();
        }

        public string Actualizar(Usuario entity)
        {
            return userRepository.Actualizar(entity);
        }

        public string Eliminar(string id)
        {
            throw new NotImplementedException();
        }
    }
        
}
