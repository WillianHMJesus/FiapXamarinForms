using System.IO;
using Windows.Storage;
using Xamarin.Forms;
using XF.LocalDB.Data;
using XF.LocalDB.UWP;

[assembly: Dependency(typeof(SQLite_UWP))]
namespace XF.LocalDB.UWP
{
    public class SQLite_UWP : IDependencyServiceSQLite
    {
        public SQLite_UWP() { }

        public SQLite.SQLiteConnection GetConexao()
        {
            var arquivodb = "fiapdb.db3";
            string caminho = Path.Combine(
                ApplicationData.Current.LocalFolder.Path, arquivodb);
            var conexao = new SQLite.SQLiteConnection(caminho);
            return conexao;
        }
    }
}
