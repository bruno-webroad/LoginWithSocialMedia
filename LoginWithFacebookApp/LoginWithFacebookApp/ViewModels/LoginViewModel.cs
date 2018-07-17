using LoginWithFacebookApp.Interfaces;
using LoginWithFacebookApp.Models;
using LoginWithFacebookApp.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace LoginWithFacebookApp.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public ICommand LoginFacebookCommand { get; set; }
        public ICommand LoginGoogleCommand { get; set; }
        private readonly IFacebookManager _facebookManager;
        private readonly IGoogleManager _googleManager;

        private FacebookUser _facebookUser;
        public FacebookUser FacebookUser
        {
            get { return _facebookUser; }
            set {
                _facebookUser = value;
                NotifyPropertyChanged("FacebookUser");
            }
        }

        private string _error;
        public string Error
        {
            get { return _error; }
            set
            {
                _error = value;
                NotifyPropertyChanged("Error");
            }
        }

        public LoginViewModel()
        {
            _facebookManager = DependencyService.Get<IFacebookManager>();
            _googleManager = DependencyService.Get<IGoogleManager>();
            LoginFacebookCommand = new Command(LoginFacebook);
            LoginGoogleCommand = new Command(LoginGoogle);    
        }

        private void LoginFacebook()
        {
            _facebookManager.Login(OnLoginCompleteFacebook);
        }

        private void LoginGoogle()
        {
            _googleManager.Login(OnLoginCompleteGoogle);
        }


        //FACEBOOK
        private async void OnLoginCompleteFacebook(FacebookUser facebookUser, string message)
        {
            if (facebookUser != null)
            {
                await App.Current.MainPage.Navigation.PushAsync(new DetailsUserPage(facebookUser, null));               
            }
            else
            {
                Error = message;
            }
        }

        //GOOGLE
        private async void OnLoginCompleteGoogle(GoogleUser googleUser, string message)
        {
            if (googleUser != null)
            {
                await App.Current.MainPage.Navigation.PushAsync(new DetailsUserPage(null, googleUser));
            }
            else
            {
                Error = message;
            }
        }
    }
}
