using Entidades;
using Persistencia;
using System;
using System.Collections.Generic;
using System.IO.Ports;

namespace Logica
{
    public class ServiceECG
    {
         private ArduinoRepositorio _conexion;
         public event Action<DatoECG> DatoRecibido;
         public List<DatoECG> Datos { get; private set; }

         public ServiceECG(string portName, int baudRate)
         {
             _conexion = new ArduinoRepositorio(portName, baudRate);
             _conexion.DatoRecibido += OnDatoRecibido; // Suscribimos el método que manejará los datos recibidos
             Datos = new List<DatoECG>();
         }

         public void IniciarLectura()
         {
             try
             {
                 _conexion.ConectarArduino();
                 Console.WriteLine("Lectura iniciada. Esperando datos del Arduino...");
                 _conexion.EscucharSerial();
             }
             catch (Exception ex)
             {
                 Console.WriteLine("No se pudo iniciar la lectura, el Arduino no está conectado.");
             }
         }

         public void DetenerLectura()
         {
             _conexion.DesconectarArduino();
             Console.WriteLine("Lectura detenida y Arduino desconectado.");
         }

         private void OnDatoRecibido(DatoECG dato)
         {
             AgregarDato(dato);
             DatoRecibido?.Invoke(dato); // Notificar a los suscriptores externos que hay un nuevo dato
         }

         private void AgregarDato(DatoECG dato)
         {
             Datos.Add(dato);
             Console.WriteLine($"Dato agregado: {dato.Valor}");
         }
    }
}
