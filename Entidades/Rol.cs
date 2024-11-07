using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Rol
    {
        public int IdRol { get; set; }
        public string NombreRol { get; set; }

        public Rol(int id, string nombreRol)
        {
            IdRol = id;
            NombreRol = nombreRol;
        }

        public Rol()
        {
        }

        public override string ToString() 
        {
            return IdRol + "; " + NombreRol;
        }
    }
}
