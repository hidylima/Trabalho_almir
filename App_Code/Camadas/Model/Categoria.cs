using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
namespace LOCAR.Camadas.Model
{
    public class Categoria
    {
        public int IdCategoria { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public int qtdeVeiculos { get; set; }
    }
}