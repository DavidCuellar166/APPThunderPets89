using PIAAppProgra.Models;
using PIAAppProgra.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.OpenWhatsApp;
using Xamarin.Forms.Xaml;

namespace PIAAppProgra.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetalleMascPage : ContentPage
    {
        public DetalleMascPage(DatosPetsModel parametros)
        {
            InitializeComponent();
            BindingContext = new DetalleMascViewModel(Navigation, parametros);
        }

        private void BtnDWhtsap_Clicked(object sender, EventArgs e)
        {
            var TEL = LblTelNueConta.Text;
            var ND = LblNomDueD.Text;
            var NM = LblNomMascD.Text;

            var mensaje = "Hola " +ND+" me gustaria adoptar a tu mascota "+ NM;

            //DisplayAlert("Hola", mensaje, "OK");

            try
            {
                if (!string.IsNullOrEmpty(mensaje))
                {
                    string CodigoPaisCelular;
                    CodigoPaisCelular = "+52"+ TEL;
                    Chat.Open(CodigoPaisCelular, mensaje);

                }
            }
            catch (Exception ex)
            {

                DisplayAlert("Alerta", ex.Message, "OK");
            }
        }
    }
}