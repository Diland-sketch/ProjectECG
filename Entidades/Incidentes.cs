using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Incidentes
    {
        public int IdIncidente { get; set; }
        public DateTime FechaHoraIncidente { get; set; }
        public string Descripcion { get; set; }
        public int IdSesionECG { get; set; }

        public Incidentes()
        {
            
        }

        public Incidentes( DateTime fechaHoraIncidente, string descripcionIncidente, int idSesion)
        {
            IdSesionECG = idSesion;
            FechaHoraIncidente = fechaHoraIncidente;
            Descripcion = descripcionIncidente;
        }

        public override string ToString()
        {
            return $"";
        }
    }
}
