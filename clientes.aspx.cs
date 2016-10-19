using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class clientes : System.Web.UI.Page
{
    protected void HabilitaCampos(bool habilita)
    {
        txtNome.Enabled = habilita;
        txtCnh.Enabled = habilita;
        txtRg.Enabled = habilita;
        txtCpf.Enabled = habilita;
        txtRua.Enabled = habilita;
        txtNumero.Enabled = habilita;
        txtBairro.Enabled = habilita;
        txtCidade.Enabled = habilita;
        txtEstado.Enabled = habilita;
        btnInserir.Enabled = !habilita;

        if (Convert.ToInt32(lblId.Text) == 0)
        {
            btnAlterar.Enabled = habilita;
            btnRemover.Enabled = habilita;
            btnCancelar.Enabled = habilita;
            btnSalvar.Enabled = habilita;
            txtNome.Text = "";
            txtCnh.Text = "";
            txtRg.Text = "";
            txtCpf.Text = "";
            txtRua.Text = "";
            txtNumero.Text = "";
            txtBairro.Text = "";
            txtCidade.Text = "";
            txtEstado.Text = "";
        }
        else
        {
            btnAlterar.Enabled = !habilita;
            btnRemover.Enabled = !habilita;
            btnCancelar.Enabled = habilita;
            btnSalvar.Enabled = habilita;
        }

        LOCAR.Camadas.BLL.Cliente bllCliente = new LOCAR.Camadas.BLL.Cliente();
        grvClientes.DataSource = bllCliente.Select();
        grvClientes.DataBind();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Cache["OP"] = "S";
            lblId.Text = "0";
            HabilitaCampos(false);
        }
    }
    protected void grvClientes_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Selecionar")
        {
            GridViewRow linha = grvClientes.Rows[Convert.ToInt16(e.CommandArgument)];
            lblId.Text = linha.Cells[1].Text;
            txtNome.Text = linha.Cells[2].Text;
            txtCnh.Text = linha.Cells[3].Text;
            txtRg.Text = linha.Cells[4].Text;
            txtCpf.Text = linha.Cells[5].Text;
            txtRua.Text = linha.Cells[6].Text;
            txtNumero.Text = linha.Cells[7].Text;
            txtBairro.Text = linha.Cells[8].Text;
            txtCidade.Text = linha.Cells[9].Text;
            txtEstado.Text = linha.Cells[10].Text;
            btnAlterar.Enabled = true;
            btnRemover.Enabled = true;
        }
    }
    protected void btnInserir_Click(object sender, EventArgs e)
    {
        lblId.Text = "-1";
        txtNome.Text = "";
        txtCnh.Text = "";
        txtRg.Text = "";
        txtCpf.Text = "";
        txtRua.Text = "";
        txtNumero.Text = "";
        txtBairro.Text = "";
        txtCidade.Text = "";
        txtEstado.Text = "";
        HabilitaCampos(true);
        txtCnh.Focus();
        Cache["OP"] = 'I';
    }
    protected void btnSalvar_Click(object sender, EventArgs e)
    {
        LOCAR.Camadas.Model.Cliente cliente = new LOCAR.Camadas.Model.Cliente();
        cliente.IdCliente = Convert.ToInt32(lblId.Text);
        cliente.Nome = txtNome.Text;
        cliente.CNH = txtCnh.Text;
        cliente.RG = txtRg.Text;
        cliente.CPF = txtCpf.Text;
        cliente.Rua = txtRua.Text;
        cliente.Numero = txtNumero.Text;
        cliente.Bairro = txtBairro.Text;
        cliente.Cidade = txtCidade.Text;
        cliente.Estado = txtEstado.Text;
        LOCAR.Camadas.BLL.Cliente bllCliente = new LOCAR.Camadas.BLL.Cliente();

        if (Cache["OP"].Equals('I'))
            bllCliente.Insert(cliente);

        else if (Cache["OP"].Equals('U'))
            bllCliente.Update(cliente);

        if (Cache["OP"].Equals('I'))
            grvClientes.SetPageIndex(grvClientes.PageCount);

        lblId.Text = "0";
        HabilitaCampos(false);
        Cache["OP"] = "S";
    }
    protected void btnAlterar_Click(object sender, EventArgs e)
    {
        Cache["OP"] = 'U';
        HabilitaCampos(true);
        txtCnh.Focus();
    }
    protected void btnRemover_Click(object sender, EventArgs e)
    {
        LOCAR.Camadas.Model.Cliente cliente = new LOCAR.Camadas.Model.Cliente();
        cliente.IdCliente = Convert.ToInt32(lblId.Text);
        cliente.Nome = txtNome.Text;
        cliente.CNH = txtCnh.Text;
        cliente.RG = txtRg.Text;
        cliente.CPF = txtCpf.Text;
        cliente.Rua = txtRua.Text;
        cliente.Numero = txtNumero.Text;
        cliente.Bairro = txtBairro.Text;
        cliente.Cidade = txtCidade.Text;
        cliente.Estado = txtEstado.Text;
        LOCAR.Camadas.BLL.Cliente bllCliente = new LOCAR.Camadas.BLL.Cliente();
        //lblId.Text = "0";
        if (Convert.ToInt32(lblId.Text) > 0)
            bllCliente.Delete(cliente);

        lblId.Text = "0";
        txtNome.Text = "";
        txtCnh.Text = "";
        txtRg.Text = "";
        txtCpf.Text = "";
        txtRua.Text = "";
        txtNumero.Text = "";
        txtBairro.Text = "";
        txtCidade.Text = "";
        txtEstado.Text = "";
        HabilitaCampos(false);
        Cache["OP"] = "S";
    }
    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        lblId.Text = "0";
        txtNome.Text = "";
        txtCnh.Text = "";
        txtRg.Text = "";
        txtCpf.Text = "";
        txtRua.Text = "";
        txtNumero.Text = "";
        txtBairro.Text = "";
        txtCidade.Text = "";
        txtEstado.Text = "";
        HabilitaCampos(false);
        Cache["OP"] = "S";
    }
}