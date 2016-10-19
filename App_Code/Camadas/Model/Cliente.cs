using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOCAR.Camadas.Model
{ 
    public class Cliente
    {
        public int IdCliente { get; set; }
        public string Nome { get; set; }
        public string CNH { get; set; }
        public string RG { get; set; }
        public string CPF { get; set; }
        public string Rua { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; } 
    }
}