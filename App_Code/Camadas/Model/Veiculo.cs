using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOCAR.Camadas.Model
{
    public class Veiculo
    {
        public int IdVeiculo { get; set; }
        public string Placa { get; set; } 
        public string Renavam { get; set; }
        public string Cor { get; set; }
        public int Categoria { get; set; }
    }
}