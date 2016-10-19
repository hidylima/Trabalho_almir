using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOCAR.Camadas.BLL
{
    public class Table //camada de devolução
    { 
        public List<Model.Table> Select()
        {
            DAL.Table dalTable = new DAL.Table();
            return dalTable.Select();
        }
        public void Insert(Model.Table table)
        {
            DAL.Table dalTable = new DAL.Table();
            dalTable.Insert(table);
        }
        public void Update(Model.Table table)
        {
            DAL.Table dalTable = new DAL.Table();
            dalTable.Update(table);
        }
        public void Delete(Model.Table table)
        {
            DAL.Table dalTable = new DAL.Table();
            dalTable.Delete(table);
        }
    }
}