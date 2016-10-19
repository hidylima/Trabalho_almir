<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="clientes.aspx.cs" Inherits="clientes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContent" Runat="Server">
     <asp:Panel runat="server" ID="pnlCadastro" Visible="true">
        <h1>Cadastra Cliente</h1>
        <ul>
            <li>
                <asp:Label Text="Código " ID="label1" runat="server"></asp:Label>
                <asp:Label ID="lblId" runat="server"></asp:Label>
            </li>
            <li>
                <asp:Label ID="Label2" runat="server" Text="Nome"></asp:Label>
                <asp:TextBox ID="txtNome"  CssClass="radiusInput" runat="server" ></asp:TextBox>
            </li>
            <li>
                <asp:Label ID="Label3" runat="server" Text="Cnh"></asp:Label>
                <asp:TextBox ID="txtCnh" CssClass="radiusInput" Enabled="false" runat="server"></asp:TextBox>
            </li>
            <li>
                <asp:Label ID="Label4" runat="server" Text="RG"></asp:Label>
                <asp:TextBox ID="txtRg" CssClass="radiusInput" Enabled="false" runat="server"></asp:TextBox>
            </li>
            <li>
                <asp:Label ID="Label5" runat="server" Text="Cpf"></asp:Label>
                <asp:TextBox ID="txtCpf" CssClass="radiusInput" Enabled="false" runat="server"></asp:TextBox>
            </li>
            <li>
                <asp:Label ID="Label10" runat="server" Text="Rua"></asp:Label>
                <asp:TextBox ID="txtRua" CssClass="radiusInput" Enabled="false" runat="server"></asp:TextBox>
            </li>
             <li>
                <asp:Label ID="Label6" runat="server" Text="Numero"></asp:Label>
                <asp:TextBox ID="txtNumero" CssClass="radiusInput" Enabled="false" runat="server"></asp:TextBox>
            </li>
             <li>
                <asp:Label ID="Label7" runat="server" Text="Bairro"></asp:Label>
                <asp:TextBox ID="txtBairro" CssClass="radiusInput" Enabled="false" runat="server"></asp:TextBox>
            </li>
             <li>
                <asp:Label ID="Label8" runat="server" Text="Cidade"></asp:Label>
                <asp:TextBox ID="txtCidade" CssClass="radiusInput" Enabled="false" runat="server"></asp:TextBox>
            </li>
            <li>
                <asp:Label ID="Label9" runat="server" Text="Estado"></asp:Label>
                <asp:TextBox ID="txtEstado" CssClass="radiusInput" Enabled="false" runat="server"></asp:TextBox>
            </li>

            <li>
            </li>
            <li>
            </li>
            <li>
                <asp:Button ID="btnSalvar" runat="server" CssClass="btnAdd btn" OnClick="btnSalvar_Click" Text="Salvar" />
            </li>
            <li>
                <asp:Button ID="btnRemover" CssClass="btn btnDelete"  runat="server" Text="Excluir" OnClick="btnRemover_Click" />
            </li>
                        <li>
                <asp:Button ID="btnAlterar" CssClass="btn btnEdit" runat="server" Text="Atualizar" OnClick="btnAlterar_Click" />
            </li>
            <li>
                <asp:Button ID="btnCancelar" CssClass="btn btnLimpa" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" />
            </li>
           <li>
                <asp:Button ID="btnInserir" CssClass="btn btnInserir" runat="server" Text="Inserir" OnClick="btnInserir_Click" />
            </li>
 
        </ul>
    </asp:Panel>
       <asp:Panel runat="server" ID="pnlShowData" Visible="true">
                <asp:GridView ID="grvClientes" runat="server" style="text-align: center" Width="697px" OnRowCommand="grvClientes_RowCommand">
                    <Columns>
                        <asp:ButtonField ButtonType="Image" CommandName="Selecionar" HeaderText="Selecionar" ImageUrl="~/images/flegar.png" Text="Button" />
                    </Columns>
                </asp:GridView>

    </asp:Panel>
</asp:Content>

