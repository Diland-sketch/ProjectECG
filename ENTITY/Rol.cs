using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY
{
    public class Rol
    {
        public string Id { get; set; }
        public string NombreRol { get; set; }

        public Rol(string id, string nombreRol)
        {
            Id = id;
            NombreRol = nombreRol;
        }

        public override string ToString() 
        {
            return Id + "; " + NombreRol;
        }
    }
}
