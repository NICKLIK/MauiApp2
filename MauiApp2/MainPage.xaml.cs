namespace MauiApp2
{
    public partial class MainPage : ContentPage
    {
        int cont = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private async void Recargar(object sender, EventArgs e)
        {

            int valor = 0;
            if (Movistar.IsChecked)
                valor = 3;
            else if (Claro.IsChecked)
                valor = 5;
            else if (Tuenti.IsChecked)
                valor = 10;


            bool confirmacion = await DisplayAlert("Confirmación", $"¿Desea recargar ${valor} al número {NNnumeroTelefonico.Text} con el operador {NNoperadoras.SelectedItem}?", "Aceptar", "No");


            if (confirmacion)
            {
                await RealizarRecarga(valor);
            }
        }
        private void ActualizarValor(object sender, CheckedChangedEventArgs e)
        {
            int valor = 0;
            if (Movistar.IsChecked)
                valor = 3;
            else if (Claro.IsChecked)
                valor = 5;
            else if (Tuenti.IsChecked)
                valor = 10;

            NNconfirmacionValor.Text = $"Ha seleccionado una recarga de: ${valor}";
        }


        private async Task RealizarRecarga(int valor)
        {

            string ubicacionDocumento = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string nombreArchivo = $"{NNnumeroTelefonico.Text}.txt";
            string ubicacionArchivo = Path.Combine(ubicacionDocumento, nombreArchivo);

            string textoArchivo = $"Estimado usuario con el numero ({NNnumeroTelefonico.Text}). Se hizo una recarga de ${valor} dólares con la operadora: {NNoperadoras.SelectedItem} en la siguiente fecha: {DateTime.Now}";

            File.WriteAllText(ubicacionArchivo, textoArchivo);
            await DisplayAlert("Recarga Exitosa", "La recarga se ha realizado exitosamente.", "Gracias");
        }
    }

}
