using System.IO;
using Xamarin.Forms;
using XF.LocalDB.Android;
using XF.LocalDB.Data;

[assembly: Dependency(typeof(SQLite_Android))]
namespace XF.LocalDB.Android
{
    public class SQLite_Android : IDependencyServiceSQLite
    {
        public SQLite_Android() { }

        public SQLite.SQLiteConnection GetConexao()
        {
            var arquivodb = "fiapdb.db3";
            string caminho = System.Environment.GetFolderPath
                (System.Environment.SpecialFolder.Personal);
            var local = Path.Combine(caminho, arquivodb);
            var conexao = new SQLite.SQLiteConnection(local);
            return conexao;
        }
    }
}