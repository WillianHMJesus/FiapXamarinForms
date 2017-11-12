using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XF.Intro.Models;

namespace XF.Intro
{
    public partial class MainPage : ContentPage
    {
        Email emailmodel;
        public MainPage()
        {
            InitializeComponent();

            if (emailmodel == null)
                emailmodel = new Email();
        }
        private void btnEnviar_Clicked(object sender, EventArgs e)
        {
            if ((emailmodel.Ativo) && (!string.IsNullOrEmpty(emailmodel.ContaEmail)))
                DisplayAlert("Mensagem",
                    $"E-mail enviado para {emailmodel.ContaEmail}", "Ok");
            else
                DisplayAlert("Mensagem", "Envio não autorizado", "Ok");
        }

        private void btnConfiguracao_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ConfigPage() { BindingContext = emailmodel });
        }
    }
}
