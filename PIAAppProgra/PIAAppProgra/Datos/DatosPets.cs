using Firebase.Database;
using Firebase.Database.Query;
using PIAAppProgra.Conexion;
using PIAAppProgra.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIAAppProgra.Datos
{
    public class DatosPets
    {
        public async Task InsertarMascota(DatosPetsModel parametros)
        {
            await CConexion.firebase
                .Child("Pets")
                .PostAsync(new DatosPetsModel()
                {
                    NomMasc = parametros.NomMasc,
                    ImaMasc = parametros.ImaMasc,
                    SexoMasc = parametros.SexoMasc,
                    DescMas = parametros.DescMas,
                    NomDue = parametros.NomDue,
                    TelDue = parametros.TelDue,
                    UbiMasc = parametros.UbiMasc
                });
        }

        public async Task<ObservableCollection<DatosPetsModel>> MostrarMascota()
        {
            var data = await Task.Run(() => CConexion.firebase
                .Child("Pets")
                .AsObservable<DatosPetsModel>()
                .AsObservableCollection());
            return data;
        }
        //public async Task<List<DatosPetsModel>> MostrarMascota()
        //{
        //    return (await CConexion.firebase
        //        .Child("Pets")
        //        .OnceAsync<DatosPetsModel>())
        //        .Select(item => new DatosPetsModel
        //        {
        //            NomMasc = item.Object.NomMasc,
        //            ImaMasc = item.Object.ImaMasc,
        //            SexoMasc = item.Object.SexoMasc,
        //            DescMas = item.Object.DescMas,
        //            NomDue = item.Object.NomDue,
        //            TelDue = item.Object.TelDue,
        //            UbiMasc = item.Object.UbiMasc

        //        }).ToList();

        //}

    }
}
