using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOCAR.Camadas.Model
{
    public class Table // camada de devolução
    {
        public int IdDevolucao { get; set; }
        public int IdCliente { get; set; }
        public int IdVeiculo { get; set; }
        public DateTime Data_devolucao { get; set; } 
    }
}