using Firebase.Auth;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PIAAppProgra.ViewModels
{
    public class ForgotPasswordUsuario
    {
        string webAPIKey = "AIzaSyBhR7sXJpm3vjUsFWw6shT66c_uOBWlav8";
        FirebaseAuthProvider authProvider;

        public ForgotPasswordUsuario()
        {
            authProvider = new FirebaseAuthProvider(new FirebaseConfig(webAPIKey));
        }

        public async Task<bool> ResetPassword(string email)
        {
            await authProvider.SendPasswordResetEmailAsync(email);
            return true;
        }

    }



}
