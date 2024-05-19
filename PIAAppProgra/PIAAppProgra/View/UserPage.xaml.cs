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
	public partial class UserPage : ContentPage
	{
		public UserPage ()
		{
			InitializeComponent ();
            BindingContext = new UserViewModel(Navigation);
        }

        private async void ListViewName_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            await Navigation.PushAsync(new EditPersonPage(e.SelectedItem as DatosUserModel));
        }

        //Clicked="CerrarSUP_Clicked"
        private async void CerrarSUP_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LoginPage());
            ////await App.Current.MainPage.Navigation.PushAsync(new LoginPage());

        }


            //        <StackLayout>


            //    <StackLayout HorizontalOptions = "Center" Orientation="Vertical" Margin="10,10,10,10" >
            //        <Button
            //         Text = "Cerrar Sesión" TextColor="#ecf0f1" Font="Montserrat-Medium.otf" BackgroundColor="#8e44ad"
            //         BorderColor="Black" BorderWidth="1.5" CornerRadius="50" WidthRequest="300" HeightRequest="50" x:Name="CerrarSUP" Clicked="CerrarSUP_Clicked"
            //        />
            //    </StackLayout>
            //</StackLayout>
    }
}