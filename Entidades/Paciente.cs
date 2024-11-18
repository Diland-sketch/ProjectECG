namespace Entidades
{
    public class Paciente : Persona
    {
        
        public SesionECG SesionECG { get; set; }
        public Paciente() { }
        public Paciente(string documento, string primerNombre, string segundoNombre, string primerApellido, string segundoApellido,
            DateOnly fechaNacmiento, char sexo)
            : base(documento, primerNombre, segundoNombre, primerApellido, segundoApellido, fechaNacmiento, sexo)
        {

        }
    }
}

