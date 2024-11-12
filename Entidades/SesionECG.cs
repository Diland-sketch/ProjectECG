using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class SesionECG
    {
        public int IdSesion  { get; set; }
        public DateTime InicioSesionECG { get; set; }
        public DateTime FinSesionECG { get; set; }
        public string Descripcion { get; set; }
        public string RutaArchivoDatos { get; set; }
        public string IdPaciente { get; set; }
        public string IdMedico { get; set; }
        public List<Incidentes> Incidentes { get; set; } = new List<Incidentes>();

        public SesionECG(int idSesion, DateTime inicioSesion, DateTime finSesion, string descripcion)
        {
            IdSesion = idSesion;
            InicioSesionECG = inicioSesion;
            FinSesionECG = finSesion;
            Descripcion = descripcion;
        }
    }
}
