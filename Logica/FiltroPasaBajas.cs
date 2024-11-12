using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class FiltroPasaBajas
    {
        private double _valorAnterior = 0;
        private double _alpha;

        public FiltroPasaBajas(double frecuenciaCorte, double frecuenciaMuestreo)
        {
            _alpha = frecuenciaCorte / (frecuenciaCorte + frecuenciaMuestreo);
        }

        public double AplicarFiltro(double valorActual)
        {
            _valorAnterior = _alpha * valorActual + (1 - _alpha) * _valorAnterior;
            return _valorAnterior;
        }
    }
}
