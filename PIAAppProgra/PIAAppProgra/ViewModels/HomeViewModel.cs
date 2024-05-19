using Firebase.Auth;
using PIAAppProgra.Conexion;
using PIAAppProgra.Datos;
using PIAAppProgra.Models;
using PIAAppProgra.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace PIAAppProgra.ViewModels
{
    public class HomeViewModel : BaseViewModel2
    {
        #region Atributos
        ObservableCollection<DatosPetsModel> _ListaPets;
        #endregion

        #region Propiedades
        public ObservableCollection<DatosPetsModel> ListaPets
        {
            get { return _ListaPets; }
            set { SetValue(ref _ListaPets, value); 
                OnPropertyChanged();
            }
        }

        #endregion

        #region Command
        public Command MostrarMascCommand { get; }
        public Command IrDetalleMascCommand { get; }


        #endregion

        #region Metodo
        public async Task MostrarPets()
        {
            var funcion = new DatosPets();
            ListaPets = await funcion.MostrarMascota();
            
        }
        //prubar con los otros que nos dirigen a otras paginas

        public async Task IrDetalleMasc(DatosPetsModel parametros)
        {
            await Navigation.PushAsync(new DetalleMascPage(parametros));
        }

        #endregion

        #region Constructor
        public HomeViewModel(INavigation navegar)
        {
            Navigation = navegar;
            MostrarPets();

            MostrarMascCommand = new Command(async () => await MostrarPets());
            IrDetalleMascCommand = new Command<DatosPetsModel>(async (p) => await IrDetalleMasc(p));

        }
        #endregion
    }
}
