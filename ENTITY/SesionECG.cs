using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY
{
    public class SesionECG
    {
        public string IdSesion  { get; set; }
        public DateTime InicioSesionECG { get; set; }
        public DateTime FinSesionECG { get; set; }
        public string Descripcion { get; set; }
        public DatoECG DatoECG { get; set; }   
        public Incidentes Incidentes { get; set; }

        public SesionECG(string idSesion, DateTime inicioSesion, DateTime finSesion, string descripcion, DatoECG datoECG, Incidentes incidentes)
        {
            IdSesion = idSesion;
            InicioSesionECG = inicioSesion;
            FinSesionECG = finSesion;
            Descripcion = descripcion;
            DatoECG = datoECG;
            Incidentes = incidentes;
        }
    }
}
