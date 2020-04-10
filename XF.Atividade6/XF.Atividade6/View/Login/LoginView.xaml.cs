using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XF.Atividade6.View.Login
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginView : ContentPage
    {
        bool authenticated = false;
        public LoginView()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            txtUsuario.Text = pwdSenha.Text = string.Empty;
            base.OnAppearing();

            if (authenticated == true)
            {
                this.loginButton.IsVisible = false;
            }
        }

        private async void loginButton_Clicked(object sender, EventArgs e)
        {
            if (App.Authenticator != null)
                authenticated = await App.Authenticator.Authenticate();
        }
    }
}