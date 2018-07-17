using LoginWithFacebookApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoginWithFacebookApp.Interfaces
{
    public interface IGoogleManager
    {
        void Login(Action<GoogleUser, string> OnLoginComplete);
        void Logout();
    }
}
