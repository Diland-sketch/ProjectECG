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
        private readonly FiltradoSeñal _filtradoSeñal;
        private double _valorAnterior = 0;

        public ServiceECG(string portName, int baudRate)
        {
            _conexion = new ArduinoRepositorio(portName, baudRate);
            _filtradoSeñal = new FiltradoSeñal();
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

        private FiltradoAvanzando filtro = new FiltradoAvanzando();

        private void ProcesarDato(DatoECG dato)
        {
            double valorNormalizado = _filtradoSeñal.NormalizarDato(dato.Valor);
            double valorFiltrado = filtro.Suavizar(valorNormalizado);

            DatoECG datoFiltrado = new DatoECG(valorFiltrado);
            DatoRecibido?.Invoke(datoFiltrado);
        }

    }
}