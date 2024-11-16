using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Persona
    {
        public string Identificacion { get; set; }
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public DateOnly FechaNacimiento { get; set; }
        public char Sexo { get; set; }

        public Persona(string documento, string primerNombre, string segundoNombre, string primerApellido, string segundoApellido, DateOnly fechaNacimiento, char sexo)
        {
            Identificacion = documento;
            PrimerNombre = primerNombre;
            SegundoNombre = segundoNombre;
            PrimerApellido = primerApellido;
            SegundoApellido = segundoApellido;
            FechaNacimiento = fechaNacimiento;
            Sexo = sexo;
        }

        public Persona()
        {
        }

        public string ObtenerNombreCompleto()
        {
            return $"{PrimerNombre} {SegundoNombre} {PrimerApellido} {SegundoApellido}";
        }
        //public int CalcularEdad()
        //{
        //    var edad = DateOnly.FromDateTime(DateTime.Today) - FechaNacmiento.Year;
        //    if (DateOnly.Now < FechaNacmiento.AddYears(edad))
        //        edad--;
        //    return edad;
        //}
        //public override string ToString()
        //{
        //    return $"- Identificacion: {Identificacion}, {ObtenerNombreCompleto()}, Edad: {CalcularEdad()} años";
        //}
    }
}
