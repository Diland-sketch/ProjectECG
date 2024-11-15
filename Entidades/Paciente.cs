namespace Entidades
{
    public class Paciente
    {
        // Propiedades de la clase Paciente
        public string Documento { get; set; }
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public DateOnly FechaNacimiento { get; set; }
        public char Sexo { get; set; }

        // Constructor que acepta parámetros
        public Paciente(string documento, string primerNombre, string segundoNombre, string primerApellido, string segundoApellido, DateOnly fechaNacimiento, char sexo)
        {
            Documento = documento;
            PrimerNombre = primerNombre;
            SegundoNombre = segundoNombre;
            PrimerApellido = primerApellido;
            SegundoApellido = segundoApellido;
            FechaNacimiento = fechaNacimiento;
            Sexo = sexo;
        }

        // Constructor sin parámetros (si lo prefieres)
        public Paciente()
        {
        }
    }
}

