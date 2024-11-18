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

        public double AplicarFiltro(double valorActual, double factor = 0.1)
        {
            _valorAnterior = _valorAnterior + factor * (valorActual - _valorAnterior);
            return _valorAnterior;
        }
    }
}
