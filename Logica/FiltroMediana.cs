using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class FiltroMediana
    {
        private Queue<double> _ventana = new Queue<double>();
        private int _tamañoVentana;

        public FiltroMediana(int tamañoVentana)
        {
            _tamañoVentana = tamañoVentana;
        }

        public double Aplicar(double nuevoValor)
        {
            _ventana.Enqueue(nuevoValor);
            if (_ventana.Count > _tamañoVentana)
            {
                _ventana.Dequeue();
            }
            return _ventana.OrderBy(x => x).ElementAt(_ventana.Count / 2);
        }
    }
}
