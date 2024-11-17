using ZXing.Net.Maui;
using Microsoft.Maui.Controls;

namespace Prueba_Maui_9;

public partial class QRScannerPage : ContentPage
{
    private bool isCodeDetected = false; // Bandera para evitar m�ltiples detecciones
    private MainPage mainPage;

    public QRScannerPage(MainPage page)
    {
        InitializeComponent();
        mainPage = page ?? throw new ArgumentNullException(nameof(page)); // Verifica que no sea null
        barcodeView.Options = new BarcodeReaderOptions()
        {
            Formats = BarcodeFormat.QrCode,
            AutoRotate = true,
            Multiple = false
        };
    }

    private async void barcodeView_BarcodesDetected(object sender, BarcodeDetectionEventArgs e)
    {
        if (isCodeDetected)
            return;

        var first = e.Results?.FirstOrDefault();
        if (first != null)
        {
            isCodeDetected = true; // Marcar como detectado para evitar m�ltiples mensajes

            await Dispatcher.DispatchAsync(new Action(async () =>
            {
                mainPage.ConsultarQR(Convert.ToInt32(first.Value));
                //await DisplayAlert("C�digo detectado", first.Value, "OK");
                // Cerrar la p�gina y regresar a la anterior
                await Navigation.PopAsync();
            }));
        }
    }

}