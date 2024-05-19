using Firebase.Auth;
using PIAAppProgra.Conexion;
using PIAAppProgra.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PIAAppProgra.ViewModels
{
    public class DetalleMascViewModel : BaseViewModel2
    {
        #region Atributos

        public DatosPetsModel parametrosRecibe {  get; set; }

        #endregion

        #region Propiedades

        #endregion

        #region Command
        public Command Volvercommand { get; }
        #endregion

        #region Metodo
        public async Task Volver()
        {
            await Navigation.PopAsync();
        }

        #endregion

        #region Constructor
        public DetalleMascViewModel(INavigation navegar, DatosPetsModel parametrosTrae)
        {
            Navigation = navegar;
            parametrosRecibe = parametrosTrae;
            Volvercommand = new Command(async () => await Volver());

        }
        #endregion
    }
}
