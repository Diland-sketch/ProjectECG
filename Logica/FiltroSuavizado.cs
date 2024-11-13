using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathNet.Numerics;

namespace Logica
{
    public class FiltroSuavizado
    {
        public double[] Suavizar(double[] data)
        {
            double[] resultado = new double[data.Length];
            int ventana = 5; 

            for (int i = 0; i < data.Length; i++)
            {
                double suma = 0;
                int conteo = 0;

                for (int j = i; j < i + ventana && j < data.Length; j++)
                {
                    suma += data[j];
                    conteo++;
                }

                resultado[i] = suma / conteo;
            }

            return resultado;
        }
    }
}
