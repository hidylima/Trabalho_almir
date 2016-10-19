using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class veiculos : System.Web.UI.Page
{
    protected void HabilitaCampos(bool habilita)
    {
        txtPlaca.Enabled = habilita;
        txtRenavam.Enabled = habilita;
        txtCor.Enabled = habilita;
        ddlCategorias.Enabled = habilita;
        btnInserir.Enabled = !habilita;

        if (Convert.ToInt32(lblId.Text) == 0)
        {
            btnAlterar.Enabled = habilita;
            btnRemover.Enabled = habilita;
            btnCancelar.Enabled = habilita;
            btnSalvar.Enabled = habilita;
            txtPlaca.Text = "";
            txtRenavam.Text = "";
            txtCor.Text = "";
        }
        else
        {
            btnAlterar.Enabled = !habilita;
            btnRemover.Enabled = !habilita;
            btnCancelar.Enabled = habilita;
            btnSalvar.Enabled = habilita;
        }

        LOCAR.Camadas.BLL.Veiculo bllVeic = new LOCAR.Camadas.BLL.Veiculo();
        grvVeiculos.DataSource = bllVeic.Select();
        grvVeiculos.DataBind();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LOCAR.Camadas.BLL.Categoria bllCateg = new LOCAR.Camadas.BLL.Categoria();

            ddlCategorias.DataTextField = "Descricao";
            ddlCategorias.DataValueField = "IdCategoria";
            ddlCategorias.DataSource = bllCateg.Select();
            ddlCategorias.DataBind();

            Cache["OP"] = "S";
            lblId.Text = "0";
            lblCategoria.Text = "0";
            HabilitaCampos(false);
        }
    }
    protected void grvVeiculos_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Selecionar")
        {
            GridViewRow linha = grvVeiculos.Rows[Convert.ToInt16(e.CommandArgument)];
            lblId.Text = linha.Cells[1].Text;
            txtPlaca.Text = linha.Cells[2].Text;
            txtRenavam.Text = linha.Cells[3].Text;
            txtCor.Text = linha.Cells[4].Text;
            lblCategoria.Text = linha.Cells[5].Text;
            ddlCategorias.SelectedValue = lblCategoria.Text;
            btnAlterar.Enabled = true;
            btnRemover.Enabled = true;
        }
    }
    protected void ddlCategorias_SelectedIndexChanged(object sender, EventArgs e)
    {
        lblCategoria.Text = ddlCategorias.SelectedValue.ToString();
    }
    protected void btnInserir_Click(object sender, EventArgs e)
    {
        lblId.Text = "-1";
        txtPlaca.Text = "";
        txtRenavam.Text = "";
        txtCor.Text = "";
        lblCategoria.Text = "0";
        HabilitaCampos(true);
        txtPlaca.Focus();
        Cache["OP"] = 'I';
    }
    protected void btnSalvar_Click(object sender, EventArgs e)
    {
        LOCAR.Camadas.Model.Veiculo veiculo = new LOCAR.Camadas.Model.Veiculo();
        veiculo.IdVeiculo = Convert.ToInt32(lblId.Text);
        veiculo.Placa = txtPlaca.Text;
        veiculo.Renavam = txtRenavam.Text;
        veiculo.Cor = txtCor.Text;
        veiculo.Categoria = Convert.ToInt32(lblCategoria.Text);
        LOCAR.Camadas.BLL.Veiculo bllVeiculo = new LOCAR.Camadas.BLL.Veiculo();

        if (Cache["OP"].Equals('I'))
            bllVeiculo.Insert(veiculo);

        else if (Cache["OP"].Equals('U'))
            bllVeiculo.Update(veiculo);

        if (Cache["OP"].Equals('I'))
            grvVeiculos.SetPageIndex(grvVeiculos.PageCount);

        lblId.Text = "0";
        lblCategoria.Text = "";
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
        LOCAR.Camadas.Model.Veiculo veiculo = new LOCAR.Camadas.Model.Veiculo();
        veiculo.IdVeiculo = Convert.ToInt32(lblId.Text);
        veiculo.Placa = txtPlaca.Text;
        veiculo.Renavam = txtRenavam.Text;
        veiculo.Cor = txtCor.Text;
        LOCAR.Camadas.BLL.Veiculo bllVeiculo = new LOCAR.Camadas.BLL.Veiculo();
        //lblId.Text = "0";
        if (Convert.ToInt32(lblId.Text) > 0)
            bllVeiculo.Delete(veiculo);

        lblId.Text = "0";
        txtPlaca.Text = "";
        txtRenavam.Text = "";
        txtCor.Text = "";
        lblCategoria.Text = "0";
        HabilitaCampos(false);
        Cache["OP"] = "S";
    }
    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        lblId.Text = "0";
        txtPlaca.Text = "";
        txtRenavam.Text = "";
        txtCor.Text = "";
        lblCategoria.Text = "0";
        HabilitaCampos(false);
        Cache["OP"] = "S";
    }
    protected void grvVeiculos_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}