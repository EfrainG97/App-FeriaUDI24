using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba_Maui_9.Model
{
    internal class Alumno
    {
        public Alumno(int iD, string? nombre, int matricula, string? modalidad, int asisM, int asisJ)
        {
            ID = iD;
            Nombre = nombre;
            Matricula = matricula;
            Modalidad = modalidad;
            AsisM = asisM;
            AsisJ = asisJ;
        }
        public Alumno() { }

        public int ID { get; set; }
        public string? Nombre { get; set; }
        public int Matricula { get; set; }
        public string? Modalidad { get; set; }
        public int AsisM { get; set; }
        public int AsisJ { get; set; }
    }
}
