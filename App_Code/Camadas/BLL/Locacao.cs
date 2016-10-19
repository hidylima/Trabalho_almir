using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOCAR.Camadas.BLL
{
    public class Locacao
    { 
        public Model.Locacao SelectLocacaoById(int Id)
        {
            DAL.Locacao dalLocacao = new DAL.Locacao();
            return dalLocacao.SelectLocacaoById(Id);
        }
        public List<Model.Locacao> Select()
        {
            DAL.Locacao dalLocacao = new DAL.Locacao();
            return dalLocacao.Select();
        }
        public void Insert(Model.Locacao locacao)
        {
            DAL.Locacao dalLocacao = new DAL.Locacao();
            dalLocacao.Insert(locacao);
        }
        public void Update(Model.Locacao locacao)
        {
            DAL.Locacao dalLocacao = new DAL.Locacao();
            dalLocacao.Update(locacao);
        }
        public void Delete(Model.Locacao locacao)
        {
            DAL.Locacao dalLocacao = new DAL.Locacao();
            dalLocacao.Delete(locacao);
        }
    }
}