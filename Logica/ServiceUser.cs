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
    public class ServiceUser 
    {
        private UsuarioRepositorio userRepository;
        public ServiceUser()
        {
            userRepository = new UsuarioRepositorio();
        }

        public string Guardar(Usuario user)
        {
            return userRepository.Guardar(user);
        }

        public int Login(Usuario usuario)
        {
            return userRepository.ValidarUsuario(usuario.NombreUsuario, usuario.Contrasenha);
        }


        public int MostrarId(string nom)
        {
            return userRepository.MostrarId(nom);
        }
        public Usuario ConsultarId(int id)
        {
            return userRepository.ConsultarId(id);
        }

        public string Actualizar(Usuario entity)
        {
            return userRepository.Actualizar(entity);
        }

        
    }
        
}
