using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY
{
    public class Paciente : Persona
    {

        public List<HistorialSesiones> historialSesiones { get; set; }
        public SesionECG SesionECG { get; set; }
    }
}
