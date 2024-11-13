using Entidades;
using Persistencia;
using System;
using System.Collections.Generic;

namespace Logica
{
    public class ServiceECG
    {
        private ArduinoRepositorio _conexion;
        public event Action<DatoECG> DatoRecibido;
        private readonly FiltroSuavizado _filtro;
        private readonly List<double> _datosAcumulados;

        private const int TamañoBloque = 50;

        public ServiceECG(string portName, int baudRate)
        {
            _conexion = new ArduinoRepositorio(portName, baudRate);
            _filtro = new FiltroSuavizado();
            _datosAcumulados = new List<double>();

            _conexion.DatoRecibido += OnDatoRecibido;
        }

        public void IniciarLectura()
        {
            if (_conexion.ConectarArduino())
            {
                Console.WriteLine("Lectura iniciada. Esperando datos del Arduino...");
            }
            else
            {
                Console.WriteLine("El Arduino ya está conectado o ha ocurrido un error.");
            }
        }

        public void DetenerLectura()
        {
            _conexion.DesconectarArduino();
            Console.WriteLine("Lectura detenida y Arduino desconectado.");
        }

        private void OnDatoRecibido(DatoECG dato)
        {
            ProcesarDato(dato);
        }

        private void ProcesarDato(DatoECG dato)
        {
            _datosAcumulados.Add(dato.Valor);

            if(_datosAcumulados.Count >= TamañoBloque)
            {
                double[] bloqueDatos = _datosAcumulados.ToArray();
                double[] bloqueFiltrado = _filtro.Suavizar(bloqueDatos);

                _datosAcumulados.Clear();

                foreach(double valorFiltrado in bloqueFiltrado)
                {
                    DatoECG datoFiltrado = new DatoECG(valorFiltrado);
                    DatoRecibido?.Invoke(datoFiltrado);
                }
            }
        }

    }
}