using Prueba_Maui_9.Controller;
using Prueba_Maui_9.Model;
using ZXing.Net.Maui.Controls;
using ZXing.Net.Maui;

namespace Prueba_Maui_9
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

        }

        public bool IsCheckM { get; set; }
        public bool IsCheckJ { get; set; }


        AlumnoController ac = new AlumnoController();

        private async void Button_Clicked(object sender, EventArgs e)
        {
            if (int.TryParse(IdEntry.Text, out int id))
            {
                try
                {
                    var persona = await ac.ObtenerAlumnoID(id);
                    if (persona != null)
                    {
                        IDLabel.Text = persona.ID.ToString();
                        NombreLabel.Text = persona.Nombre;
                        MatriculaLabel.Text = persona.Matricula.ToString();
                        ModalidadLabel.Text = persona.Modalidad;
                        if (IsCheckM = persona.AsisM == 1)
                        {
                            CheckBoxM.IsEnabled = false;
                        }
                        else
                        {
                            CheckBoxM.IsEnabled = true;
                        }
                        if (IsCheckJ = persona.AsisJ == 1)
                        {
                            CheckBoxJ.IsEnabled = false;
                        }
                        else
                        {
                            CheckBoxJ.IsEnabled = true;
                        }
                        CheckBoxM.IsChecked = IsCheckM;
                        CheckBoxJ.IsChecked = IsCheckJ;
                    }
                    else
                    {
                        await DisplayAlert("No encontrado", "No se encontro una persona con el ID ingresado", "Ok");
                    }
                }
                catch (Exception ex)
                {
                    await DisplayAlert("Error", $"Ocurrio un error al obtener los datos: {ex.Message}", "Ok");
                }
            }
        }

        private async void updButton_Clicked(object sender, EventArgs e)
        {
            Alumno al = new Alumno();

            int id = Convert.ToInt32(IDLabel.Text);
            al.Nombre = NombreLabel.Text;
            al.Matricula = Convert.ToInt32(MatriculaLabel.Text);
            al.Modalidad = ModalidadLabel.Text;
            al.AsisM = Convert.ToInt32(CheckBoxM.IsChecked);
            al.AsisJ = Convert.ToInt32(CheckBoxJ.IsChecked);

            try
            {
                if (await ac.ActualizarAlumno(id, new Alumno(id, al.Nombre, al.Matricula, al.Modalidad, al.AsisM, al.AsisJ)))
                {
                    LimpiarCampos();
                    await DisplayAlert("Exito", "Se ha revisado asitencia con exito", "Ok");
                }
                else
                {
                    await DisplayAlert("Error", "Hubo un problema al revisar asistencia", "Ok");
                }

            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"Ocurrio un error al obtener los datos: {ex.Message}", "Ok");
            }

        }

        private void LimpiarCampos()
        {
            NombreLabel.Text = string.Empty;
            MatriculaLabel.Text = string.Empty;
            ModalidadLabel.Text = string.Empty;
            IdEntry.Text = string.Empty;
            IsCheckM = false;
            IsCheckJ = false;
            IDLabel.Text = string.Empty;
        }

        private async void scanButton_Clicked(object sender, EventArgs e)
        {
            var qrScannerPage = new QRScannerPage(this);
            await Navigation.PushAsync(qrScannerPage);
        }
        public async void ConsultarQR(int id)
        {
            try
            {
                var persona = await ac.ObtenerAlumnoID(id);
                if (persona != null)
                {
                    IDLabel.Text = persona.ID.ToString();
                    NombreLabel.Text = persona.Nombre;
                    MatriculaLabel.Text = persona.Matricula.ToString();
                    ModalidadLabel.Text = persona.Modalidad;
                    if (IsCheckM = persona.AsisM == 1)
                    {
                        CheckBoxM.IsEnabled = false;
                    }
                    else
                    {
                        CheckBoxM.IsEnabled = true;
                    }
                    if (IsCheckJ = persona.AsisJ == 1)
                    {
                        CheckBoxJ.IsEnabled = false;
                    }
                    else
                    {
                        CheckBoxJ.IsEnabled = true;
                    }
                    CheckBoxM.IsChecked = IsCheckM;
                    CheckBoxJ.IsChecked = IsCheckJ;
                }
                else
                {
                    await DisplayAlert("No encontrado", "No se encontro una persona con el ID ingresado", "Ok");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"Ocurrio un error al obtener los datos: {ex.Message}", "Ok");
            }
        }
    }
}


