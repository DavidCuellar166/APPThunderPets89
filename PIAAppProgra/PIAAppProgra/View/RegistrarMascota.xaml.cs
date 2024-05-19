using Firebase.Storage;
using PIAAppProgra.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PIAAppProgra.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegistrarMascota : ContentPage
    {
        public RegistrarMascota()
        {
            InitializeComponent();
            BindingContext = new RegiMascViewModel(Navigation);
        }

        private async void BtnCargarImaMasRegistro_Clicked(object sender, EventArgs e)
        {
            var imagen = await Xamarin.Essentials.MediaPicker.PickPhotoAsync();
            if (imagen == null)
            {
                await DisplayAlert("Imagen NO Seleccionada", "Favor de seleccionar una Imagen", "Aceptar");
                return;
            }
            else
            {
                var task = new FirebaseStorage("piaprogra-2a3e4.appspot.com", new FirebaseStorageOptions
                {
                    ThrowOnCancel = true
                })
                .Child("Imagenes")
                .Child("MascUsu")
                .Child(imagen.FileName)
                .PutAsync(await imagen.OpenReadAsync());

                task.Progress.ProgressChanged += (s, args) =>
                {
                    BarraDeCargaFotoMascRegistro.Progress = args.Percentage;
                };

                var linkdecarga1 = await task;
                LinkDeCargaFMascRegistro.Text = linkdecarga1;
                await DisplayAlert("Carga Exitosa", "Su imagen se ha cargado de forma correcta y puede obtener su vínculo", "Aceptar");
                MostrarLinkDeLaImagenMasc.Text = linkdecarga1;
                BtnObtLikImgMascRegistro.IsEnabled = true;

            }
        }

        private void BtnObtLikImgMascRegistro_Clicked(object sender, EventArgs e)
        {
            NomMascRegistro.IsEnabled = true;
            SexoMascRegistro.IsEnabled = true;
            UbiMascRegistro.IsEnabled = true;
            DescMascRegistro.IsEnabled = true;
            NomDueRegistro.IsEnabled = true;
            TelDueRegistro.IsEnabled = true;

            ImagenMascRegi.Text = LinkDeCargaFMascRegistro.Text;
            RegistrarNuevoUsuario.IsVisible = true;
        }

        private void BotonVistapreviaRM_Clicked(object sender, EventArgs e)
        {
            VistaPreviaMasc.IsVisible = true;
            RecImagenRM.Source = ImagenMascRegi.Text;
            BtnSexoRM.Text = SexoMascRegistro.Text;
            LabelNombreRM.Text = NomMascRegistro.Text;
            BotonVistapreviaRM.IsVisible = false;
            BotonQUITARVistapreviaRM.IsVisible =true;
        }

        private void BotonQUITARVistapreviaRM_Clicked(object sender, EventArgs e)
        {
            VistaPreviaMasc.IsVisible = false;
            BotonVistapreviaRM.IsVisible = true;
            BotonQUITARVistapreviaRM.IsVisible = false;
        }
    }
}