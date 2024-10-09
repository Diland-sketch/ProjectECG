using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY
{
    public class Persona
    {
        public string Documento { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime FechaNacmiento { get; set; }
        public char Sexo { get; set; }
        protected Persona(string nombre, string apellido, string documento, DateTime fechaNacmiento, char sexo)
        {
            Nombre = nombre;
            Apellido = apellido;
            Documento = documento;
            FechaNacmiento = fechaNacmiento;
            Sexo = sexo;
        }
        public Persona()
        {
            
        }
        public string ObtenerNombreCompleto()
        {
            return $"{Nombre} {Apellido}";
        }
        public int CalcularEdad()
        {
            var edad = DateTime.Now.Year - FechaNacmiento.Year;
            if (DateTime.Now < FechaNacmiento.AddYears(edad))
                edad--;
            return edad;
        }
        public override string ToString()
        {
            return $"{ObtenerNombreCompleto()} - Documento: {Documento}, Edad: {CalcularEdad()} años";
        }
    }
}
