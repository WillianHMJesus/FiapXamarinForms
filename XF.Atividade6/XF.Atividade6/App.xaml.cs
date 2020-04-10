using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XF.Atividade6.ViewModel;


namespace XF.Atividade6
{
    public interface IAuthenticate
    {
        Task<bool> Authenticate();
    }

    public partial class App : Application, IAuthenticate
    {
        public static IAuthenticate Authenticator { get; private set; }

        public static void Init(IAuthenticate authenticator)
        {
            Authenticator = authenticator;
        }

        public static UsuarioViewModel UsuarioVM { get; set; }

        public App()
        {
            InitializeComponent();
            InitializeApplication();

            MainPage = new NavigationPage(new View.Atividade.MainPage());
        }

        private void InitializeApplication()
        {
            if (UsuarioVM == null) UsuarioVM = new UsuarioViewModel();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

        public Task<bool> Authenticate()
        {
            throw new NotImplementedException();
        }
    }
}
