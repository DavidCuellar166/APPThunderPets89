using PIAAppProgra.Conexion;
using PIAAppProgra.Datos;
using PIAAppProgra.Models;
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
	public partial class HomePage : ContentPage
	{
        public HomePage ()
		{
			InitializeComponent ();
            BindingContext = new HomeViewModel(Navigation);
        }
    }
}