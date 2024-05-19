using Firebase.Auth;
using PIAAppProgra.Conexion;
using PIAAppProgra.Datos;
using PIAAppProgra.Models;
using PIAAppProgra.View;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PIAAppProgra.ViewModels
{
    public class RegiMascViewModel : BaseViewModel
    {
        #region Atributos
        string _nommasc;
        string _sexomasc;
        string _ubimasc;
        string _descmasc;
        string _nomduemasc;
        string _telduemasc;
        string _imamasc;
        string email;
        string clave;

        #endregion

        #region Propiedades


        public string NomMascTxt
        {
            get { return _nommasc; }
            set { SetValue(ref _nommasc, value); }
        }
        public string SexoMascTxt
        {
            get { return _sexomasc; }
            set { SetValue(ref _sexomasc, value); }
        }
        public string UbiMascTxt
        {
            get { return _ubimasc; }
            set { SetValue(ref _ubimasc, value); }
        }
        public string DescMascTxt
        {
            get { return _descmasc; }
            set { SetValue(ref _descmasc, value); }
        }
        public string NomDueTxt
        {
            get { return _nomduemasc; }
            set { SetValue(ref _nomduemasc, value); }
        }
        public string TelDueTxt
        {
            get { return _telduemasc; }
            set { SetValue(ref _telduemasc, value); }
        }
        public string ImagenMascTxt
        {
            get { return _imamasc; }
            set { SetValue(ref _imamasc, value); }
        }

        #endregion

        #region Command
        public Command InsertarMascCommand { get; }

        public Command RegMascAUserCommand { get; }
        public Command RegMascARegMascCommand { get; }
        public Command RegMascAHomCommand { get; }
        #endregion

        #region Metodo
        public async Task InsertarPets()
        {
            if (string.IsNullOrEmpty(this._nommasc))
            {
                await Application.Current.MainPage.DisplayAlert("Campo Vacío","Por favor ingresa el NOMBRE de su Mascota","Aceptar");
                return;
            }

            if (string.IsNullOrEmpty(this._sexomasc))
            {
                await Application.Current.MainPage.DisplayAlert("Campo Vacío", "Por favor ingresa el SEXO de su Mascota", "Aceptar");
                return;
            }
            if (string.IsNullOrEmpty(this._ubimasc))
            {
                await Application.Current.MainPage.DisplayAlert("Campo Vacío", "Por favor ingresa la UBICACION de su Mascota", "Aceptar");
                return;
            }
            if (string.IsNullOrEmpty(this._descmasc))
            {
                await Application.Current.MainPage.DisplayAlert("Campo Vacío", "Por favor ingresa la RAZON DE ADOPCION de su Mascota", "Aceptar");
                return;
            }
            if (string.IsNullOrEmpty(this._nomduemasc))
            {
                await Application.Current.MainPage.DisplayAlert("Campo Vacío", "Por favor ingresa el DUEÑO de su Mascota", "Aceptar");
                return;
            }
            if (string.IsNullOrEmpty(this._telduemasc))
            {
                await Application.Current.MainPage.DisplayAlert("Campo Vacío", "Por favor ingresa el TELEFONO DE CONTACTO de su Mascota", "Aceptar");
                return;
            }

            var funcion = new DatosPets();
            var parametros = new DatosPetsModel();
            parametros.NomMasc = NomMascTxt;
            parametros.SexoMasc = SexoMascTxt;
            parametros.UbiMasc = UbiMascTxt;
            parametros.DescMas = DescMascTxt;
            parametros.NomDue = NomDueTxt;
            parametros.TelDue = TelDueTxt;
            parametros.ImaMasc = ImagenMascTxt;

            await funcion.InsertarMascota(parametros);

            await App.Current.MainPage.DisplayAlert("Información", "Su Mascota ha sido registrada con exito", "Aceptar");
            await Navigation.PushAsync(new IndexMenu());

            ////await Application.Current.MainPage.Navigation.PushAsync(new IndexMenu());

        }






        #endregion

        #region Constructor
        public RegiMascViewModel(INavigation navegar)
        {
            Navigation = navegar;
            InsertarMascCommand = new Command(async () => await InsertarPets());


        }
        #endregion
    }
}
