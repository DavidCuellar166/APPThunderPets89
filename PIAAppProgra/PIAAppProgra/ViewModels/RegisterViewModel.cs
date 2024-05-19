using Firebase.Auth;
using Firebase.Database;
using Firebase.Database.Query;
using PIAAppProgra.Conexion;
using PIAAppProgra.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PIAAppProgra.ViewModels
{
    public class RegisterViewModel : BaseViewModel
    {
        FirebaseClient firebase = new FirebaseClient("https://piaprogra-2a3e4-default-rtdb.firebaseio.com/");

        #region Attributes
        public string emailR;
        public string passwordR;
        public string nameR;
        public string telR;
        public string imaperR;


        //public bool isRunning;
        //public bool isVisible;
        //public bool isEnabled;
        #endregion

        #region Properties
        public string EmailTxt
        {
            get { return this.emailR; }
            set { SetValue(ref this.emailR, value); }
        }

        public string PasswordTxt
        {
            get { return this.passwordR; }
            set { SetValue(ref this.passwordR, value); }
        }

        public string NombreUTxt
        {
            get { return this.nameR; }
            set { SetValue(ref this.nameR, value); }
        }

        public string TelefonoUTxt
        {
            get { return this.telR; }
            set { SetValue(ref this.telR, value); }
        }

        public string ImagenPerfilTxt
        {
            get { return this.imaperR; }
            set { SetValue(ref this.imaperR, value); }
        }

        public string userId;
        public string emailUsu;
        public string idusuario;

        #endregion

        #region Commands

        public Command RegisterCommand { get; }
        #endregion

        #region Methods
        public async Task RegisterMethod()
        {
            if (string.IsNullOrEmpty(this.emailR))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Campo Vacío",
                    "Por favor ingresa tu CORREO",
                    "Aceptar");
                return;
            }

            if (string.IsNullOrEmpty(this.passwordR))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Campo Vacío",
                    "Por favor ingresa tu CONTRASEÑA",
                    "Aceptar");
                return;
            }

            if (string.IsNullOrEmpty(this.nameR))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Campo Vacío",
                    "Por favor ingresa tu NOMBRE",
                    "Aceptar");
                return;
            }

            if (string.IsNullOrEmpty(this.telR))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Campo Vacío",
                    "Por favor ingresa tu TELEFONO",
                    "Aceptar");
                return;
            }


            var objusuario = new UserModel()
            {
                EmailField = emailR,
                PasswordField = passwordR,
            };


            try
            {
                var authProvider = new FirebaseAuthProvider(new FirebaseConfig(DBConn.WebApyAuthentication));
                var auth = await authProvider.CreateUserWithEmailAndPasswordAsync(objusuario.EmailField.ToString(), objusuario.PasswordField.ToString());
                string gettoken = auth.FirebaseToken;

                userId = auth.User.LocalId;
                emailUsu = auth.User.Email;

                await App.Current.MainPage.DisplayAlert("Información", "Sus datos han sido cargados con exito", "Aceptar");
                //await App.Current.MainPage.DisplayAlert("Información", userId, "Aceptar");
                //await App.Current.MainPage.DisplayAlert("Información", emailUsu, "Aceptar");

                await firebase
                        .Child("Users")
                        .Child(userId)
                        .PostAsync(new DatosUserModel()
                        {
                            Email = emailR,
                            Nombre = nameR,
                            Telefono = telR,
                            ImagenPerfil = imaperR
                        });
                await App.Current.MainPage.DisplayAlert("Información", "Su Usuario ha sido creado con exito", "Aceptar");

                await Navigation.PushAsync(new LoginPage());
                //await Application.Current.MainPage.Navigation.PushAsync(new LoginPage());

            }
            catch (Exception)
            {
                await App.Current.MainPage.DisplayAlert("Advertencia", "Los datos introducidos son incorrectos o el usuario se encuentra inactivo.", "Aceptar");
            }


            #endregion

        }
        public async Task<bool> RegistrarUs(DatosUserModel parametros)
        {
            await firebase
                .Child("Users")
                .Child(userId)
                .PostAsync(new DatosUserModel()
                {
                    Email = parametros.Email,
                    Nombre = parametros.Nombre,
                    Telefono = parametros.Telefono,
                    ImagenPerfil = parametros.ImagenPerfil
                });
            return true;
        }


        #region Constructor
        public RegisterViewModel(INavigation navegar)
        {
            Navigation = navegar;
            RegisterCommand = new Command(async () => await RegisterMethod());
        }
        #endregion
    }
}
