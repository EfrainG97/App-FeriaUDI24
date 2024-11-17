using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Prueba_Maui_9.Model;
using Newtonsoft.Json;

namespace Prueba_Maui_9.Controller
{
    internal class AlumnoController : IAlumno
    {
        public static HttpClient CrearCliente()
        {
            var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("http://10.0.2.2:85/");
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return httpClient;
        }

        private static readonly HttpClient client = CrearCliente();

        public async Task<Alumno> ObtenerAlumnoID(int id)
        {
            HttpResponseMessage response = await client.GetAsync($"api/Alumno/{id}");
            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                var alumnos = JsonConvert.DeserializeObject<Alumno>(jsonResponse);
                return alumnos;
            }
            return null;
        }

        public async Task<bool> ActualizarAlumno(int id, Alumno alumno)
        {
            var json = JsonConvert.SerializeObject(alumno);
            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PutAsync($"api/Alumno/{id}", content);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }
    }
}
