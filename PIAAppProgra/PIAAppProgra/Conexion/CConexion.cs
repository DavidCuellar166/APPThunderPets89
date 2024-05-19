using Firebase.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace PIAAppProgra.Conexion
{
    public class CConexion
    {
        public static FirebaseClient firebase = new FirebaseClient("https://piaprogra-2a3e4-default-rtdb.firebaseio.com/");
    }
}
