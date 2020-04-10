using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XF.Contatos.Model
{
    public class Telefone
    {
        public Telefone() { }

        public PhoneType Tipo { get; set; }
        public string Descricao { get; set; }
        public string Numero { get; set; }
    }

    public enum PhoneType
    {
        Home = 0,
        HomeFax = 1,
        Work = 2,
        WorkFax = 3,
        Pager = 4,
        Mobile = 5,
        Other = 6
    }
}
