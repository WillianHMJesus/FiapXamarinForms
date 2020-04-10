using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using XF.Atividade6.Model;

namespace XF.Atividade6.ViewModel
{
    public class AtividadeViewModel : INotifyPropertyChanged
    {
        IMobileServiceTable<Atividade> atividadeTable;
        MobileServiceClient client;

        static AtividadeViewModel instancia = new AtividadeViewModel();
        public static AtividadeViewModel Instancia
        {
            get { return instancia; }
            private set { instancia = value; }
        }

        public Atividade AtividadeModel { get; set; }

        private Atividade selecionado;
        public Atividade Selecionado
        {
            get { return selecionado; }
            set
            {
                selecionado = value as Atividade;
                EventPropertyChanged();
            }
        }

        public ObservableCollection<Atividade> Atividades { get; set; } = new ObservableCollection<Atividade>();

        public OnAdicionarAtividadeCMD OnAdicionarAtividadeCMD { get; }
        public OnEditarAtividadeCMD OnEditarAtividadeCMD { get; }
        public OnDeleteAtividadeCMD OnDeleteAtividadeCMD { get; }
        public ICommand OnSairCMD { get; private set; }
        public ICommand OnNovoCMD { get; private set; }

        public AtividadeViewModel()
        {
            client = new MobileServiceClient("https://xfaplicativofiap.azurewebsites.net");
            atividadeTable = client.GetTable<Atividade>();

            OnAdicionarAtividadeCMD = new OnAdicionarAtividadeCMD(this);
            OnEditarAtividadeCMD = new OnEditarAtividadeCMD(this);
            OnDeleteAtividadeCMD = new OnDeleteAtividadeCMD(this);
            OnSairCMD = new Command(OnSair);
            OnNovoCMD = new Command(OnNovo);
        }

        public async Task Carregar()
        {
            IEnumerable<Atividade> items = await atividadeTable
              .ToEnumerableAsync();
            Atividades = new ObservableCollection<Atividade>(items);
        }

        public async void Adicionar(Atividade paramAtividade)
        {
            await atividadeTable.InsertAsync(paramAtividade);
        }

        public async void Editar()
        {
            await App.Current.MainPage.Navigation.PushAsync(
                new View.Atividade.NovoAtividadeView() { BindingContext = Instancia });
        }

        public async void Remover()
        {
            if (await App.Current.MainPage.DisplayAlert("Atenção?",
                string.Format("Tem certeza que deseja remover a Atividade?"), "Sim", "Não"))
            {
                await atividadeTable.DeleteAsync(Selecionado);
            }
        }

        private void OnNovo()
        {
            Instancia.Selecionado = new Atividade();
            App.Current.MainPage.Navigation.PushAsync(
                new View.Atividade.NovoAtividadeView() { BindingContext = Instancia });
        }

        private async void OnSair()
        {
            await App.Current.MainPage.Navigation.PopAsync();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void EventPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

    public class OnAdicionarAtividadeCMD : ICommand
    {
        private AtividadeViewModel atividadeVM;
        public OnAdicionarAtividadeCMD(AtividadeViewModel paramVM)
        {
            atividadeVM = paramVM;
        }
        public event EventHandler CanExecuteChanged;
        public void AdicionarCanExecuteChanged() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        public bool CanExecute(object parameter) => true;
        public void Execute(object parameter)
        {
            atividadeVM.Adicionar(parameter as Atividade);
        }
    }

    public class OnEditarAtividadeCMD : ICommand
    {
        private AtividadeViewModel atividadeVM;
        public OnEditarAtividadeCMD(AtividadeViewModel paramVM)
        {
            atividadeVM = paramVM;
        }
        public event EventHandler CanExecuteChanged;
        public void EditarCanExecuteChanged() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        public bool CanExecute(object parameter) => (parameter != null);
        public void Execute(object parameter)
        {
            AtividadeViewModel.Instancia.Selecionado = parameter as Atividade;
            atividadeVM.Editar();
        }
    }

    public class OnDeleteAtividadeCMD : ICommand
    {
        private AtividadeViewModel atividadeVM;
        public OnDeleteAtividadeCMD(AtividadeViewModel paramVM)
        {
            atividadeVM = paramVM;
        }
        public event EventHandler CanExecuteChanged;
        public void DeleteCanExecuteChanged() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        public bool CanExecute(object parameter) => (parameter != null);
        public void Execute(object parameter)
        {
            AtividadeViewModel.Instancia.Selecionado = parameter as Atividade;
            atividadeVM.Remover();
        }
    }
}
