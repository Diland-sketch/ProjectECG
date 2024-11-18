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
        private FiltroPasaBajas FiltroPasaBajas = new FiltroPasaBajas();
        private FiltroMediana filtroMediana = new FiltroMediana(5);

        public ServiceECG(string portName, int baudRate)
        {
            _conexion = new ArduinoRepositorio(portName, baudRate);
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
            double valorFiltrado = filtroMediana.Aplicar(dato.Valor);
            valorFiltrado = FiltroPasaBajas.AplicarFiltro(valorFiltrado);
            DatoECG datoFiltrado = new DatoECG(valorFiltrado);
            DatoRecibido?.Invoke(datoFiltrado);
        }
    }
}