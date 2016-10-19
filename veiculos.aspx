<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="veiculos.aspx.cs" Inherits="veiculos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContent" Runat="Server">
    <asp:Panel runat="server" ID="pnlCadastro" Visible="true">
        <h1>Cadastra Categorias</h1>
        <ul>
            <li>
                <asp:Label Text="Código" ID="label1" runat="server"></asp:Label>
                <asp:Label  ID="lblId" runat="server"></asp:Label>
            </li>
            <li>
                <asp:Label ID="Label2" runat="server" Text="Placa"></asp:Label>
                <asp:TextBox ID="txtPlaca"  CssClass="radiusInput" runat="server" ></asp:TextBox>
            </li>
            <li>
                <asp:Label ID="Label3" runat="server" Text="Renavam"></asp:Label>
                <asp:TextBox ID="txtRenavam" CssClass="radiusInput" Enabled="false" runat="server"></asp:TextBox>
            </li>
            <li>
                <asp:Label ID="Label4" runat="server" Text="Cor"></asp:Label>
                <asp:TextBox ID="txtCor" CssClass="radiusInput" Enabled="false" runat="server"></asp:TextBox>
            </li>
            <li>
                <asp:Label ID="Label5" runat="server" Text="Categoria"></asp:Label>
                <asp:Label  ID="lblCategoria" runat="server" Width="90px"></asp:Label>
                <asp:DropDownList ID="ddlCategorias" runat="server" CssClass="auto-style10" Height="25px" Width="189px" AutoPostBack="True" OnSelectedIndexChanged="ddlCategorias_SelectedIndexChanged">
                </asp:DropDownList>
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
                <asp:GridView ID="grvVeiculos" runat="server" style="text-align: center" Width="697px" OnRowCommand="grvVeiculos_RowCommand" OnSelectedIndexChanged="grvVeiculos_SelectedIndexChanged">
                    <Columns>
                        <asp:ButtonField ButtonType="Image" CommandName="Selecionar" HeaderText="Selecionar" ImageUrl="~/images/flegar.png" Text="Button" />
                    </Columns>
                </asp:GridView>

    </asp:Panel>
</asp:Content>

