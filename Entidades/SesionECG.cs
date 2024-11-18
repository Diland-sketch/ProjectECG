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
        public string IdPaciente { get; set; }
        public string IdMedico { get; set; }
        public SesionECG()
        {

        }
        public List<Incidentes> Incidentes { get; set; } = new List<Incidentes>();

        public SesionECG(int idSesion, DateTime inicioSesionECG, DateTime finSesionECG, string descripcion, string idPaciente, string idMedico, Incidentes incidentes)
        {
            IdSesion = idSesion;
            InicioSesionECG = inicioSesionECG;
            FinSesionECG = finSesionECG;
            IdPaciente = idPaciente;
            IdMedico = idMedico;
            Descripcion = descripcion;
        }
    }
}
