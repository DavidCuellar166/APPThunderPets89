using PIAAppProgra.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PIAAppProgra
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ForgotPasswordPage : ContentPage
	{
        ForgotPasswordUsuario _userRepository = new ForgotPasswordUsuario();
        public ForgotPasswordPage ()
		{
			InitializeComponent ();
		}

        private async void ButtonSendLink_Clicked(object sender, EventArgs e)
        {
            string email = TxtEmailFP.Text;
            if (string.IsNullOrEmpty(email))
            {
                await DisplayAlert("Alerta", "Por favor ingresa tu correo de recuperación.", "Ok");
                return;
            }

            bool isSend = await _userRepository.ResetPassword(email);
            if (isSend)
            {
                await DisplayAlert("Restablece tu Contraseña", "Se ha enviado un link de recuperación al correo proporcionado.", "Ok");
                await Navigation.PopModalAsync();
            }
            else
            {
                await DisplayAlert("Restablece tu Contraseña", "No se ha podido enviar el link de recuperación, verifica tu correo proporcionado.", "Ok");
            }

        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LoginPage());
            ////await Application.Current.MainPage.Navigation.PushAsync(new LoginPage());

        }
    }
}