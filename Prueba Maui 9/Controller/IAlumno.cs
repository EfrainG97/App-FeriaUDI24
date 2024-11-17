using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prueba_Maui_9.Model;

namespace Prueba_Maui_9.Controller
{
    internal interface IAlumno
    {
        public Task<Alumno> ObtenerAlumnoID(int id);
        Task<bool> ActualizarAlumno(int id, Alumno alumno);
    }
}
