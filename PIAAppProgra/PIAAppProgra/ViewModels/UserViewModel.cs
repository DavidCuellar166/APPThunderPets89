using Firebase.Auth;
using Firebase.Database.Query;
using PIAAppProgra.Conexion;
using PIAAppProgra.Models;
using PIAAppProgra.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace PIAAppProgra.ViewModels
{
    public class UserViewModel : BaseViewModel2
    {
        #region Atributos
        public object listViewSource;

        public string nombreUP;
        public string telUP;
        public string imaperUP;
        public string emailUP;
        #endregion

        #region Propiedades

        private static string v_IDusuario = "";

        public static string IDusuario
        {
            get { return v_IDusuario; }
            set { v_IDusuario = value; }
        }

        public object ListViewSource
        {

            get { return this.listViewSource; }
            set
            {
                SetValue(ref this.listViewSource, value);
            }
        }

        public string NombreUPTxt
        {
            get { return this.nombreUP; }
            set { SetValue(ref this.nombreUP, value); }
        }
        public string TelUPTxt
        {
            get { return this.telUP; }
            set { SetValue(ref this.telUP, value); }
        }

        public string EmailUPTxt
        {
            get { return this.emailUP; }
            set { SetValue(ref this.emailUP, value); }
        }

        public string ImaPerUPTxt
        {
            get { return this.imaperUP; }
            set { SetValue(ref this.imaperUP, value); }
        }

        #endregion

        #region Command
        public Command MostrarInfoCommand { get; }

        public Command UpdateCommand { get; }


        #endregion

        #region Metodo

        public async Task<List<DatosUserModel>> GetAllPersons()
        {
            return (await CConexion.firebase
              .Child("Users")
              .Child(IDusuario)
              .OnceAsync<DatosUserModel>()).Select(item => new DatosUserModel
              {
                  Nombre = item.Object.Nombre,
                  Telefono = item.Object.Telefono,
                  Email = item.Object.Email,
                  ImagenPerfil = item.Object.ImagenPerfil

              }).ToList();
        }

        public async Task LoadData()
        {
            this.ListViewSource = await GetAllPersons();
        }

        public async Task UpdatePerson(DatosUserModel _personModel)
        {
            await CConexion.firebase.Child("Users").Child(IDusuario).DeleteAsync();

            await CConexion.firebase
            .Child("Users")
            .Child(IDusuario)
            .PostAsync(new DatosUserModel() { Nombre = _personModel.Nombre, Telefono = _personModel.Telefono, ImagenPerfil = _personModel.ImagenPerfil, Email = _personModel.Email });

        }

        public async Task UpdateMethod()
        {

            var person = new DatosUserModel
            {
                Email = EmailUPTxt,
                Nombre = NombreUPTxt,
                Telefono = TelUPTxt,
                ImagenPerfil = ImaPerUPTxt,

            };
            await UpdatePerson(person);

            await Navigation.PushAsync(new IndexMenu());
            ////await App.Current.MainPage.Navigation.PushAsync(new LoginPage());
            //await Navigation.PopAsync();
        }





        #endregion

        #region Constructor
        public UserViewModel(INavigation navegar)
        {
            Navigation = navegar;
            LoadData();
            MostrarInfoCommand = new Command(async () => await LoadData());

        }

        public UserViewModel(INavigation navegar, DatosUserModel _personModel)
        {
            Navigation = navegar;

            EmailUPTxt = _personModel.Email;
            NombreUPTxt = _personModel.Nombre;
            TelUPTxt = _personModel.Telefono;
            ImaPerUPTxt = _personModel.ImagenPerfil.ToString();

            UpdateCommand = new Command(async () => await UpdateMethod());
        }
        #endregion
    }
}
