using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY
{
    public class DatoECG
    {
        public double Valor { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFinalizacion { get; set; }

        public DatoECG(double valor)
        {
            Valor = valor;
            FechaInicio = DateTime.Now;
        }
    }
}
