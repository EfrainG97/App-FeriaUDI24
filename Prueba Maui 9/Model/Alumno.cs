using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba_Maui_9.Model
{
    internal class Alumno
    {
        public Alumno(int iDAlumno, string? nombre, int matricula, string? modalidad, int asisMar, int asisMie, int asisConf)
        {
            IDAlumno = iDAlumno;
            Nombre = nombre;
            Matricula = matricula;
            Modalidad = modalidad;
            AsisMar = asisMar;
            AsisMie = asisMie;
            AsisConf = asisConf;
        }

        public Alumno()
        {
        }

        public int IDAlumno { get; set; }
        public string? Nombre { get; set; }
        public int Matricula { get; set; }
        public string? Modalidad { get; set; }
        public int AsisMar { get; set; }
        public int AsisMie { get; set; }
        public int AsisConf { get; set; }
    }
}
