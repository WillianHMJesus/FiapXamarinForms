using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XF.Atividade6.Model
{
    public class Atividade
    {
        public int Id { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataEntrega { get; set; }
        public Avaliacao TipoAvaliacao { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
    }

    public enum Avaliacao
    {
        Parcial,
        Substitutiva
    }
}
