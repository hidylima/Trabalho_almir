using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class locacoes : System.Web.UI.Page
{

    protected void HabilitaCampos(bool habilita)
    {
        txtCliente.Enabled = habilita;
        txtPlaca.Enabled = habilita;
        txtDataLoc.Enabled = habilita;
        txtDataDev.Enabled = habilita;
        txtValor.Enabled = habilita;
        btnInserir.Enabled = !habilita;

        if (Convert.ToInt32(lblId.Text) == 0)
        {
            btnAlterar.Enabled = habilita;
            //btnRemover.Enabled = habilita;
            btnCancelar.Enabled = habilita;
            btnSalvar.Enabled = habilita;
            txtCliente.Text = "";
            txtPlaca.Text = "";
            txtDataLoc.Text = "";
            txtDataDev.Text = "0";
            txtValor.Text = "";
        }
        else
        {
            btnAlterar.Enabled = !habilita;
            //btnRemover.Enabled = !habilita;
            btnCancelar.Enabled = habilita;
            btnSalvar.Enabled = habilita;
        }

        LOCAR.Camadas.BLL.Locacao bllLocacao = new LOCAR.Camadas.BLL.Locacao();
        grvLocacoes.DataSource = bllLocacao.Select();
        grvLocacoes.DataBind();
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
    protected void grvLocacoes_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Selecionar")
        {
            GridViewRow linha = grvLocacoes.Rows[Convert.ToInt16(e.CommandArgument)];
            lblId.Text = linha.Cells[1].Text;
            txtCliente.Text = linha.Cells[2].Text;
            txtPlaca.Text = linha.Cells[3].Text;
            txtDataLoc.Text = linha.Cells[4].Text;
            txtDataDev.Text = linha.Cells[5].Text;
            txtValor.Text = linha.Cells[6].Text;
            btnAlterar.Enabled = true;
            //btnRemover.Enabled = true;
        }
    }
    protected void btnInserir_Click(object sender, EventArgs e)
    {
        lblId.Text = "-1";
        txtCliente.Text = "";
        txtPlaca.Text = "";
        txtDataLoc.Text = "";
        txtDataDev.Text = "0";
        txtValor.Text = "";
        HabilitaCampos(true);
        txtPlaca.Focus();
        Cache["OP"] = 'I';
    }
    protected void btnSalvar_Click(object sender, EventArgs e)
    {
        LOCAR.Camadas.Model.Locacao locacao = new LOCAR.Camadas.Model.Locacao();
        locacao.IdLocacao = Convert.ToInt32(lblId.Text);
        locacao.IdCliente = txtCliente.Text;
        locacao.IdVeiculo = txtPlaca.Text;
        locacao.Data_locacao = txtDataLoc.Text;
        locacao.Data_devolucao = txtDataDev.Text;
        locacao.Valor_total = Convert.ToInt32(txtValor.Text);
        LOCAR.Camadas.BLL.Locacao bllLocacao = new LOCAR.Camadas.BLL.Locacao();

        if (Cache["OP"].Equals('I'))
            bllLocacao.Insert(locacao);

        else if (Cache["OP"].Equals('U'))
            bllLocacao.Update(locacao);

        if (Cache["OP"].Equals('I'))
            grvLocacoes.SetPageIndex(grvLocacoes.PageCount);

        lblId.Text = "0";
        HabilitaCampos(false);
        Cache["OP"] = "S";
    }
    protected void btnAlterar_Click(object sender, EventArgs e)
    {
        Cache["OP"] = 'U';
        HabilitaCampos(true);
        txtPlaca.Focus();
    }
    protected void btnRemover_Click(object sender, EventArgs e)
    {

    }
    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        lblId.Text = "0";
        txtCliente.Text = "";
        txtPlaca.Text = "";
        txtDataLoc.Text = "";
        txtDataDev.Text = "0";
        txtValor.Text = "";
        HabilitaCampos(false);
        Cache["OP"] = "S";
    }

}