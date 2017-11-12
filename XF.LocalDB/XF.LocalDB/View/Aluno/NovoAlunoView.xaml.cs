using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XF.LocalDB.ViewModel;

namespace XF.LocalDB.View.Aluno
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NovoAlunoView : ContentPage
    {
        public static AlunoViewModel AlunoVM { get; set; }

        public NovoAlunoView()
        {
            InitializeComponent();
        }
    }
}