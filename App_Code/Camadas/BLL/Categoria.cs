using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOCAR.Camadas.BLL
{ 
    public class Categoria
    {
        public Model.Categoria SelectCategoriaById(int id)
        {
            DAL.Categoria dalCategoria = new DAL.Categoria();
            return dalCategoria.SelectCategoriaById(id);
        }
        public List<Model.Categoria> Select()
        {
            DAL.Categoria dalCategoria = new DAL.Categoria();
            return dalCategoria.Select();
        }
        public void Insert(Model.Categoria categoria)
        {
            DAL.Categoria dalCategoria = new DAL.Categoria();
            dalCategoria.Insert(categoria);
        }
        public void Update(Model.Categoria categoria)
        {
            DAL.Categoria dalCategoria = new DAL.Categoria();
            dalCategoria.Update(categoria);
        }
        public void Delete(Model.Categoria categoria)
        {
            DAL.Categoria dalCategoria = new DAL.Categoria();
            dalCategoria.Delete(categoria);
        }
    }
}