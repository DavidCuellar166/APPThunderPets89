using Firebase.Storage;
using PIAAppProgra.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

//x:Name="EnviarButton"

namespace PIAAppProgra
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class RegistrerPage : ContentPage
	{
		public RegistrerPage ()
		{
			InitializeComponent ();
            BindingContext = new RegisterViewModel(Navigation);
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LoginPage());
            ////await Application.Current.MainPage.Navigation.PushAsync(new LoginPage());
        }

        private void BtnObtLikImgPerfRegister_Clicked(object sender, EventArgs e)
        {
            CorreoNUsuario.IsEnabled = true;
            ContraNUsuario.IsEnabled = true;
            NombreNuSUsuario.IsEnabled = true;
            TelefonoNUsuario.IsEnabled = true;

            ImagenPerfil.Text = LinkDeCargaFPUsua.Text;
            RegistrarNuevoUsuario.IsVisible = true;
        }

        private async void BtnCargarImaPerRegister_Clicked(object sender, EventArgs e)
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
                    BarraDeCargaSFRegister.Progress = args.Percentage;
                };

                var linkdecarga1 = await task;
                LinkDeCargaFPUsua.Text = linkdecarga1;
                await DisplayAlert("Carga Exitosa", "Su imagen se ha cargado de forma correcta y puede obtener su vínculo", "Aceptar");
                MostrarLinkDelaimagen.Text = linkdecarga1;
                BtnObtLikImgPerfRegister.IsEnabled = true;
                
            }
        }
    }
        
}