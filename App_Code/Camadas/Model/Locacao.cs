using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOCAR.Camadas.Model
{
    public class Locacao
    {
        public int IdLocacao { get; set; } 
        public string IdCliente { get; set; }
        public string IdVeiculo { get; set; }
        public string Data_locacao { get; set; }
        public string Data_devolucao { get; set; }
        public decimal Valor_total { get; set; }
    }
}