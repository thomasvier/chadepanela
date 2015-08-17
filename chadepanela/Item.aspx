<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Item.aspx.cs" Inherits="chadepanela.Item" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">        
    <h2>Itens</h2>
    <asp:MultiView ID="mvItem" runat="server" ActiveViewIndex="0">
        <asp:View ID="vwItens" runat="server">
            <asp:Button ID="btnInserir" runat="server" Text="Inserir novo" CssClass="btn" OnClick="btnInserir_Click" />
            <br /><br />
            <asp:GridView ID="gvItens" runat="server" GridLines="None" AutoGenerateColumns="false" Width="500">
                <Columns>
                    <asp:BoundField HeaderText="Código" DataField="id" SortExpression="id" Visible="false" />
                    <asp:BoundField HeaderText="Descrição" DataField="descricao" SortExpression="descricao" />
                    <asp:BoundField HeaderText="Lista" DataField="lista" SortExpression="lista" />
                </Columns>
            </asp:GridView>
        </asp:View>
        <asp:View ID="vwCadastro" runat="server">
            <div class="row">
                <div class="col-md-4">
                    <h4>Descrição</h4>            
                    <asp:TextBox ID="txtDescricao" runat="server" Width="600" MaxLength="255"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-md-4">
                    <h4>Lista</h4>            
                    <asp:DropDownList ID="ddlLista" runat="server" Width="600"></asp:DropDownList>
                </div>
            </div>
            <br />
            <asp:Button ID="btnSalvar" runat="server" Text="Salvar" CssClass="btn" OnClick="btnSalvar_Click"/>
        </asp:View>
    </asp:MultiView>
    <asp:HiddenField ID="hfOperacao" runat="server" />
</asp:Content>
