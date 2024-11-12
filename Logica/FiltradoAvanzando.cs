using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class FiltradoAvanzando
    {
        private Queue<double> _ventana = new Queue<double>();
        private int _tamañoVentana;

        public FiltradoAvanzando(int tamañoVentana = 10)
        {
            _tamañoVentana = tamañoVentana;
        }

        public double Suavizar(double valor)
        {
            _ventana.Enqueue(valor);
            if (_ventana.Count > _tamañoVentana)
            {
                _ventana.Dequeue();
            }

            // Media móvil de toda la ventana para suavizar
            double promedio = _ventana.Average();

            // Atenuar los picos alejados del promedio
            if (Math.Abs(valor - promedio) > 10)
            {
                return promedio + 0.2 * (valor - promedio);
            }
            else
            {
                return promedio;
            }
        }
    }

}
