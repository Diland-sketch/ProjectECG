using ENTITY;
using System;
using System.Collections.Generic;
using System.IO.Ports;

namespace DAL
{
    public class ArduinoRepositorio
    {
        /*private SerialPort _serialPort;

        public event Action<DatoECG> DatoRecibido;

        public ArduinoRepositorio(string portName, int puerto)
        {
            _serialPort = new SerialPort(portName, puerto);
            _serialPort.DataReceived += OnDatoRecibido;
        }

        public bool ConectarArduino()
        {
            try
            {
                if (!_serialPort.IsOpen)
                {
                    _serialPort.Open();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al conectar con el Arduino: {ex.Message}");
                return false;
            }
        }
        public void DesconectarArduino()
        {
            if (_serialPort != null && _serialPort.IsOpen)
            {
                _serialPort.Close();
            }
        }
        private void OnDatoRecibido(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                string data = _serialPort.ReadLine();
                Console.WriteLine($"Dato recibido: {data}"); // Verificar los datos recibidos
                if (double.TryParse(data, out double valor))
                {
                    DatoECG dato = new DatoECG(valor);
                    DatoRecibido?.Invoke(dato);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error leyendo datos del puerto serial: {ex.Message}");
            }
        }*/

        private SerialPort _serialPort;
        public event Action<DatoECG> DatoRecibido;

        public ArduinoRepositorio(string portName, int baudRate)
        {
            _serialPort = new SerialPort
            {
                PortName = portName,
                BaudRate = baudRate,
                DataBits = 8,
                Parity = Parity.None,
                StopBits = StopBits.One,  // Cambiado a One
                ReadTimeout = 1000 // Aumentado el tiempo de espera para evitar timeouts cortos
            };

            _serialPort.DataReceived += OnDatoRecibido;
        }

        public bool ConectarArduino()
        {
            try
            {
                _serialPort.Open();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Falla en arduino");
                return false;
            }
        }

        public void EscucharSerial() 
        {
            if (_serialPort.IsOpen && _serialPort != null)
            {
                try
                {
                
                    string data = _serialPort.ReadLine();

                    if (int.TryParse(data, out int valor))
                    {
                        DatoECG dato = new DatoECG(valor);

                        DatoRecibido?.Invoke(dato);

                        Console.WriteLine("Dato recibido");
                    }
                    else
                    {
                        Console.WriteLine($"Error al convertir el dato");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error al leer del puerto serial");
                }
            }
            else
            {
                Console.WriteLine("El puerto serial no está abierto.");
            }
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
                    Console.WriteLine($"Dato recibido: {valor}");
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
        public void DesconectarArduino()
        {
            if (_serialPort != null && _serialPort.IsOpen)
            {
                _serialPort.Close();
                _serialPort.DataReceived -= OnDatoRecibido;
            }
        }
    }
}
