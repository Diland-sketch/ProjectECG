﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Incidentes
    {
        public string IdIncidente { get; set; }
        public DateTime FechaHoraIncidente { get; set; }
        public string DescripcionIncidente { get; set; }


        public Incidentes(string idIncidente, DateTime fechaHoraIncidente, string descripcionIncidente)
        {
            IdIncidente = idIncidente;
            FechaHoraIncidente = fechaHoraIncidente;
            DescripcionIncidente = descripcionIncidente;
        }

        public override string ToString()
        {
            return $"";
        }
    }
}
