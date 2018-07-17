using LoginWithFacebookApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoginWithFacebookApp.Interfaces
{
    public interface IFacebookManager
    {
        void Login(Action<FacebookUser, string> onLoginComplete);
        void Logout();
    }
}
