using Firebase.Storage;
using PIAAppProgra.Models;
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
    public partial class EditPersonPage : ContentPage
    {
        public EditPersonPage(DatosUserModel _personModel)
        {
            InitializeComponent();
            BindingContext = new UserViewModel(Navigation);
            BindingContext = new UserViewModel(Navigation, _personModel);
        }

        private async void CargarImagenUsuarioUPDATE_Clicked(object sender, EventArgs e)
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
                .Child("PerfilUsuarios")
                .Child(imagen.FileName)
                .PutAsync(await imagen.OpenReadAsync());

                task.Progress.ProgressChanged += (s, args) =>
                {
                    BarraDeCargaUPDATE.Progress = args.Percentage;
                };

                var linkdecargaUPDATE = await task;
                LinkDeCargaFPUsuaUPDATE.Text = linkdecargaUPDATE;
                await DisplayAlert("Carga Exitosa", "Su imagen se ha cargado de forma correcta y puede obtener su vínculo", "Aceptar");
                MostrarLinkDelaimagenUPDATE.Text = linkdecargaUPDATE;
                PasarLinkImagenACargaUPDATE.IsEnabled = true;
                BtnActualizarEPP.IsEnabled = true;
            }
        }

        private void PasarLinkImagenACargaUPDATE_Clicked(object sender, EventArgs e)
        {
            ImagenNuevaUPdate.Text = LinkDeCargaFPUsuaUPDATE.Text;
            LabelNameEPP.IsEnabled = true;
            LabelTelEPP.IsEnabled=true;
        }
    }
}