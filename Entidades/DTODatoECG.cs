using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class DTODatoECG
    {
        public string IdDatoECG { get; set; }
        public string RutaArchivoDatos { get; set; }

        public DTODatoECG(string idDatoECG, string rutaArchivoDatos)
        {
            IdDatoECG = idDatoECG;
            RutaArchivoDatos = rutaArchivoDatos;
        }
    }
}
