using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY
{
    public class Medico : Usuario
    {
        public string IdMedico { get; set; }

        public override string ToString()
        {
            return IdMedico + this.Nombre;
        }
    }
}
