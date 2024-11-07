using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Rol
    {
        public string IdRol { get; set; }
        public string NombreRol { get; set; }

        public Rol(string id, string nombreRol)
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
