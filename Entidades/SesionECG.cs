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
        public Incidentes Incidentes { get; set; }

        public SesionECG(int idSesion, DateTime inicioSesionECG, DateTime finSesionECG, string descripcion, string rutaArchivoDatos, string idPaciente, string idMedico, Incidentes incidentes)
        {
            IdSesion = idSesion;
            InicioSesionECG = inicioSesionECG;
            FinSesionECG = finSesionECG;
            Descripcion = descripcion;
            RutaArchivoDatos = rutaArchivoDatos;
            IdPaciente = idPaciente;
            IdMedico = idMedico;
            Incidentes = incidentes;
        }
    }
}
