using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
namespace LOCAR.Camadas.BLL
{
    public class Cliente
    {
        public Model.Cliente SelectClienteById(int Id)
        {
            DAL.Cliente dalCliente = new DAL.Cliente();
            return dalCliente.SelectClienteById(Id);
        }
        public List<Model.Cliente> SelectClienteByNome( string Nome)
        {
            DAL.Cliente dalCliente = new DAL.Cliente();
            return dalCliente.SelectClienteByNome(Nome);
        }
        public List<Model.Cliente> Select()
        {
            DAL.Cliente dalCliente = new DAL.Cliente();
            return dalCliente.Select();
        }
        public void Insert(Model.Cliente cliente)
        {
            DAL.Cliente dalCliente = new DAL.Cliente();
            dalCliente.Insert(cliente);
        }
        public void Update(Model.Cliente cliente)
        {
            DAL.Cliente dalCliente = new DAL.Cliente();
            dalCliente.Update(cliente);
        }
        public void Delete(Model.Cliente cliente)
        {
            DAL.Cliente dalCliente = new DAL.Cliente();
            dalCliente.Delete(cliente);
        }
    }
}