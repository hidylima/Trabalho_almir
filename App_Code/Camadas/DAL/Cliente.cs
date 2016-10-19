using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOCAR.Camadas.DAL
{
    public class Cliente
    {
        private string strCon = @"Data Source=LUIZ\TESTES;Initial Catalog=Trabalho;Integrated Security=True";
        public Model.Cliente SelectClienteById(int Id)
        {
            Model.Cliente cliente = new Model.Cliente();
            SqlConnection conexao = new SqlConnection(strCon);
            string sql = "Select * from Cliente where IdCliente = @Id";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@Id", Id);
            conexao.Open();
            SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            try
            {
                if (reader.Read())
                {
                    cliente.IdCliente = Convert.ToInt32(reader["IdCliente"]);
                    cliente.Nome = reader["Nome"].ToString();
                    cliente.CNH = reader["CNH"].ToString();
                    cliente.RG = reader["RG"].ToString();
                    cliente.CPF = reader["CPF"].ToString();
                    cliente.Rua = reader["Rua"].ToString();
                    cliente.Numero = reader["Numero"].ToString();
                    cliente.Bairro = reader["Bairro"].ToString();
                    cliente.Cidade = reader["Cidade"].ToString();
                    cliente.Estado = reader["Estado"].ToString();
                }
            }
            catch
            {
                Console.WriteLine("Deu erro na execucao de select de cliente por Codigo..");
            }
            finally
            {
                conexao.Close();
            }
            return cliente;
        }
        public List<Model.Cliente> SelectClienteByNome(string Nome)
        {
            List<Model.Cliente> lstCliente = new List<Model.Cliente>();
            SqlConnection conexao = new SqlConnection(strCon);
            string sql = "Select * from Cliente where (Nome like @nome)";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@nome", Nome +"%");
            conexao.Open();
            SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            try
            {
                while (reader.Read())
                {
                    Model.Cliente cliente = new Model.Cliente();
                    cliente.IdCliente = Convert.ToInt32(reader["IdCliente"]);
                    cliente.Nome = reader["Nome"].ToString();
                    cliente.CNH = reader["CNH"].ToString();
                    cliente.RG = reader["RG"].ToString();
                    cliente.CPF = reader["CPF"].ToString();
                    cliente.Rua = reader["Rua"].ToString();
                    cliente.Numero = reader["Numero"].ToString();
                    cliente.Bairro = reader["Bairro"].ToString();
                    cliente.Cidade = reader["Cidade"].ToString();
                    cliente.Estado = reader["Estado"].ToString();
                    lstCliente.Add(cliente);
                }
            }
            catch
            {
                Console.WriteLine("Deu erro na execucao de select de cliente por nome..");
            }
            finally
            {
                conexao.Close();
            }
            return lstCliente;
        }
        public List<Model.Cliente> Select()
        {
            List<Model.Cliente> lstCliente = new List<Model.Cliente>();
            SqlConnection conexao = new SqlConnection(strCon);
            string sql = "Select * from Cliente";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            conexao.Open();
            SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            try
            {
                while (reader.Read())
                {
                    Model.Cliente cliente = new Model.Cliente();
                    cliente.IdCliente = Convert.ToInt32(reader["IdCliente"]);
                    cliente.Nome = reader["Nome"].ToString();
                    cliente.CNH = reader["CNH"].ToString();
                    cliente.RG = reader["RG"].ToString();
                    cliente.CPF = reader["CPF"].ToString();
                    cliente.Rua = reader["Rua"].ToString();
                    cliente.Numero = reader["Numero"].ToString();
                    cliente.Bairro = reader["Bairro"].ToString();
                    cliente.Cidade = reader["Cidade"].ToString();
                    cliente.Estado = reader["Estado"].ToString();
                    lstCliente.Add(cliente);
                }
            }
            finally
            {
                conexao.Close();
            }
            return lstCliente;
        }
        public void Insert(Model.Cliente cliente)
        {
            SqlConnection conexao = new SqlConnection(strCon);
            string sql = "Insert into CLiente values (@Nome, @CNH, @RG, @CPF, @Rua, @Num, @Bairro, @Cidade, @Estado)";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@Nome", cliente.Nome);
            cmd.Parameters.AddWithValue("@CNH", cliente.CNH);
            cmd.Parameters.AddWithValue("@RG", cliente.RG);
            cmd.Parameters.AddWithValue("@CPF", cliente.CPF);
            cmd.Parameters.AddWithValue("@Rua", cliente.Rua);
            cmd.Parameters.AddWithValue("@Num", cliente.Numero);
            cmd.Parameters.AddWithValue("@Bairro", cliente.Bairro);
            cmd.Parameters.AddWithValue("@CIdade", cliente.Cidade);
            cmd.Parameters.AddWithValue("@Estado", cliente.Estado);
            conexao.Open();
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch
            {
                Console.WriteLine("Deu erro na insercao de Clientes");
            }
            finally
            {
                conexao.Close();
            }
        }
        public void Update(Model.Cliente cliente)
        {
            SqlConnection conexao = new SqlConnection(strCon);
            string sql = "Update Cliente set Nome=@Nome, CNH=@CNH, RG=@RG, CPF=@CPF, Rua=@Rua, Numero=@Num, Bairro=@Bairro, Cidade=@Cidade, Estado=@Estado where IdCliente=@IdCliente";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@IdCliente", cliente.IdCliente);
            cmd.Parameters.AddWithValue("@Nome", cliente.Nome);
            cmd.Parameters.AddWithValue("@CNH", cliente.CNH);
            cmd.Parameters.AddWithValue("@RG", cliente.RG);
            cmd.Parameters.AddWithValue("@CPF", cliente.CPF);
            cmd.Parameters.AddWithValue("@Rua", cliente.Rua);
            cmd.Parameters.AddWithValue("@Num", cliente.Numero);
            cmd.Parameters.AddWithValue("@Bairro", cliente.Bairro);
            cmd.Parameters.AddWithValue("@CIdade", cliente.Cidade);
            cmd.Parameters.AddWithValue("@Estado", cliente.Estado);
            conexao.Open();
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch
            {
                Console.WriteLine("Deu erro na atualizacao de Clientes...");
            }
            finally
            {
                conexao.Close();
            }
        }
        public void Delete(Model.Cliente cliente)
        {
            SqlConnection conexao = new SqlConnection(strCon);
            string sql = "Delete from Cliente where IdCliente=@IdCliente;";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@IdCliente", cliente.IdCliente);
            conexao.Open();
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch
            {
                Console.WriteLine("Deu erro na remocao de Cliente...");
            }
            finally
            {
                conexao.Close();
            }
        }
    }
}