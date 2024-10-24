using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY
{
    public class Persona
    {
        private string nombre;
        private string apellido;
        private string documento;

        public string Identificacion { get; set; }
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public DateTime FechaNacmiento { get; set; }
        public char Sexo { get; set; }

        public Persona(string documento, string primerNombre, string segundoNombre, string primerApellido, string segundoApellido, DateTime fechaNacmiento, char sexo)
        {
            Identificacion = documento;
            PrimerNombre = primerNombre;
            SegundoNombre = segundoNombre;
            PrimerApellido = primerApellido;
            SegundoApellido = segundoApellido;
            FechaNacmiento = fechaNacmiento;
            Sexo = sexo;
        }

        public Persona()
        {
            
        }

        public Persona(string nombre, string apellido, string documento, DateTime fechaNacmiento, char sexo)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.documento = documento;
            FechaNacmiento = fechaNacmiento;
            Sexo = sexo;
        }

        public string ObtenerNombreCompleto()
        {
            return $"{PrimerNombre} {SegundoNombre} {PrimerApellido} {SegundoApellido}";
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
            return $"- Identificacion: {Identificacion}, {ObtenerNombreCompleto()}, Edad: {CalcularEdad()} años";
        }
    }
}
