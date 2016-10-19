using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class categorias : System.Web.UI.Page
{
    protected void HabilitaCampos(bool habilita)
    {
        txtDescricao.Enabled = habilita;
        txtValor.Enabled = habilita;
        txtQtde.Enabled = habilita;
        btnInserir.Enabled = !habilita;

        if (Convert.ToInt32(lblId.Text) == 0)
        {
            btnAlterar.Enabled = habilita;
            btnRemover.Enabled = habilita;
            btnCancelar.Enabled = habilita;
            btnSalvar.Enabled = habilita;
            txtDescricao.Text = "";
            txtValor.Text = "";
        }
        else
        {
            btnAlterar.Enabled = !habilita;
            btnRemover.Enabled = !habilita;
            btnCancelar.Enabled = habilita;
            btnSalvar.Enabled = habilita;
        }

        LOCAR.Camadas.BLL.Categoria bllCategoria = new LOCAR.Camadas.BLL.Categoria();
        grvCategorias.DataSource = bllCategoria.Select();
        grvCategorias.DataBind();
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
    protected void grvCategorias_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Selecionar")
        {
            GridViewRow linha = grvCategorias.Rows[Convert.ToInt16(e.CommandArgument)];
            lblId.Text = linha.Cells[1].Text;
            txtDescricao.Text = linha.Cells[2].Text;
            txtValor.Text = linha.Cells[3].Text;
            txtQtde.Text = linha.Cells[4].Text;
            btnAlterar.Enabled = true;
            btnRemover.Enabled = true;
        }
    }
    protected void btnInserir_Click(object sender, EventArgs e)
    {
        Cache["OP"] = 'X';
        lblId.Text = "-1";
        txtDescricao.Text = "";
        txtValor.Text = "";
        txtQtde.Text = "0";
        HabilitaCampos(true);
        txtQtde.Enabled = true;
        txtDescricao.Focus();
        
    }
    protected void btnSalvar_Click(object sender, EventArgs e)
    {
        LOCAR.Camadas.Model.Categoria categoria = new LOCAR.Camadas.Model.Categoria();
        categoria.IdCategoria = Convert.ToInt32(lblId.Text);
        categoria.Descricao = txtDescricao.Text;
        categoria.Valor = Convert.ToInt32(txtValor.Text);
        categoria.qtdeVeiculos = Convert.ToInt32(txtQtde.Text);
        LOCAR.Camadas.BLL.Categoria bllCategoria = new LOCAR.Camadas.BLL.Categoria();

        if (Cache["OP"].Equals('X'))
        {
            bllCategoria.Insert(categoria);
        }
        else if (Cache["OP"].Equals('U'))
        {
            bllCategoria.Update(categoria);
        }
        if (Cache["OP"].Equals('I'))
        {
            grvCategorias.SetPageIndex(grvCategorias.PageCount);
        }

        lblId.Text = "0";
        txtQtde.Text = "0";
        HabilitaCampos(false);
        Cache["OP"] = "S";
    }
    protected void btnAlterar_Click(object sender, EventArgs e)
    {
        Cache["OP"] = 'U';
        HabilitaCampos(true);
        txtQtde.Enabled = false;
        txtDescricao.Focus();
    }
    protected void btnRemover_Click(object sender, EventArgs e)
    {
        LOCAR.Camadas.Model.Categoria categoria = new LOCAR.Camadas.Model.Categoria();
        categoria.IdCategoria = Convert.ToInt32(lblId.Text);
        categoria.Valor = Convert.ToInt32(txtValor.Text);
        categoria.qtdeVeiculos = Convert.ToInt32(txtQtde.Text);
        LOCAR.Camadas.BLL.Categoria bllCategoria = new LOCAR.Camadas.BLL.Categoria();
        //lblId.Text = "0";
        if (Convert.ToInt32(lblId.Text) > 0)
            bllCategoria.Delete(categoria);

        lblId.Text = "0";
        txtDescricao.Text = "";
        txtValor.Text = "";
        txtQtde.Text = "0";
        HabilitaCampos(false);
        Cache["OP"] = "S";
    }
    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        lblId.Text = "0";
        txtDescricao.Text = "";
        txtValor.Text = "";
        txtQtde.Text = "0";
        HabilitaCampos(false);
        Cache["OP"] = "S";
    }
    protected void grvCategorias_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void btnSalvar_Click1(object sender, EventArgs e)
    {

    }
}