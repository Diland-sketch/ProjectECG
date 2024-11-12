using Entidades;
using System;
using System.IO.Ports;

namespace Persistencia
{
    public class ArduinoRepositorio
    {
        private SerialPort _serialPort;
        public event Action<DatoECG> DatoRecibido;

        public ArduinoRepositorio(string portName, int baudRate)
        {
            _serialPort = new SerialPort(portName, baudRate)
            {
                DataBits = 8,
                Parity = Parity.None,
                StopBits = StopBits.One,
                ReadTimeout = 1000
            };

            _serialPort.DataReceived += OnDatoRecibido;
        }

        public bool ConectarArduino()
        {
            if (_serialPort.IsOpen) return false;

            try
            {
                _serialPort.Open();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al conectar con el Arduino: {ex.Message}");
                return false;
            }
        }

        public void DesconectarArduino()
        {
            if (!_serialPort.IsOpen) return;

            _serialPort.Close();
            _serialPort.DataReceived -= OnDatoRecibido;
        }

        private void OnDatoRecibido(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                string data = _serialPort.ReadLine();
                if (double.TryParse(data, out double valor))
                {
                    DatoECG dato = new DatoECG(valor);
                    DatoRecibido?.Invoke(dato);
                }
                else
                {
                    Console.WriteLine($"Error al convertir el dato: {data}");
                }
            }
            catch (TimeoutException)
            {
                Console.WriteLine("Timeout al leer del puerto serial.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error leyendo datos del puerto serial: {ex.Message}");
            }
        }
    }
}