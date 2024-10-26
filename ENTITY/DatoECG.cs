using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY
{
    public class DatoECG
    {
        public string IdDatoECG { get; set; }
        public string RutaArchivoDatos { get; set; }

        public DatoECG(string idDatoECG, string rutaArchivoDatos)
        {
            IdDatoECG = idDatoECG;
            RutaArchivoDatos = rutaArchivoDatos;
        }
    }
}
