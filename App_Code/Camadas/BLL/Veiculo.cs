using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOCAR.Camadas.BLL
{
    public class Veiculo
    {
        public Model.Veiculo SelectVeiculoById(int Id)
        {
            DAL.Veiculo dalVeiculo = new DAL.Veiculo();
            return dalVeiculo.SelectVeiculoById(Id);
        }
        public List<Model.Veiculo> SelectVeiculoByPlaca(string Placa)
        { 
            DAL.Veiculo dalVeiculo = new DAL.Veiculo();
            return dalVeiculo.SelectVeiculoByPlaca(Placa);
        }
        public List<Model.Veiculo> Select()
        {
            DAL.Veiculo dalVeiculo = new DAL.Veiculo();
            return dalVeiculo.Select();
        }
        public void Insert(Model.Veiculo veiculo)
        {
            DAL.Veiculo dalveiculo = new DAL.Veiculo();
            BLL.Categoria bllCategoria = new BLL.Categoria();
            Model.Categoria categoria = new Model.Categoria();
            categoria = bllCategoria.SelectCategoriaById(veiculo.Categoria);
            categoria.qtdeVeiculos = categoria.qtdeVeiculos + 1;
            bllCategoria.Update(categoria);
            dalveiculo.Insert(veiculo);
        }
        public void Update(Model.Veiculo veiculo)
        {
            DAL.Veiculo dalVeiculo = new DAL.Veiculo();
            dalVeiculo.Update(veiculo);
        }
        public void Delete(Model.Veiculo veiculo)
        {
            DAL.Veiculo dalVeiculo = new DAL.Veiculo();
            BLL.Categoria bllCategoria = new BLL.Categoria();
            Model.Categoria categoria = new Model.Categoria();
            categoria = bllCategoria.SelectCategoriaById(veiculo.Categoria);
            categoria.qtdeVeiculos = categoria.qtdeVeiculos - 1;
            bllCategoria.Update(categoria);
            dalVeiculo.Delete(veiculo);
        }
    }
}