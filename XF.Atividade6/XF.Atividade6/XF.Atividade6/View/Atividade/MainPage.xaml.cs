using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XF.Atividade6.ViewModel;

namespace XF.Atividade6.View.Atividade
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            BindingContext = AtividadeViewModel.Instancia;
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            lstAtividades.IsRefreshing = !lstAtividades.IsRefreshing;
            await AtividadeViewModel.Instancia.Carregar();
            lstAtividades.IsRefreshing = !lstAtividades.IsRefreshing;
        }
    }
}