<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Item.aspx.cs" Inherits="chadepanela.Item" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">        
    <h2>Itens</h2>
    <asp:MultiView ID="mvItem" runat="server" ActiveViewIndex="0">
        <asp:View ID="vwItens" runat="server">
            <asp:Button ID="btnInserir" runat="server" Text="Inserir novo" CssClass="btn" OnClick="btnInserir_Click" />
            <br /><br />
            <asp:GridView ID="gvItens" runat="server" GridLines="None" CssClass="grid" AutoGenerateColumns="false" Width="700"
                OnRowCommand="gvItens_RowCommand">
                <Columns>
                    <asp:TemplateField HeaderText="Editar" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="50px">
                        <ItemTemplate>                        
                            <asp:ImageButton ID="btnEditar" runat="server" CssClass="btnGrid" CommandName="Editar" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"
                                ImageUrl="~/Imagens/edit.png" ToolTip="Editar..." />
                        </ItemTemplate> 
                    </asp:TemplateField>
                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Excluir" HeaderStyle-Width="50px">
                        <ItemTemplate>                        
                            <asp:ImageButton ID="btnExcluir" runat="server" CssClass="btnGrid" CommandName="Excluir" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"
                                ImageUrl="~/Imagens/delete.png" ToolTip="Excluir..." />
                        </ItemTemplate> 
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="Código" DataField="id" SortExpression="id" HeaderStyle-CssClass="gridHidden" ItemStyle-CssClass="gridHidden" />
                    <asp:BoundField HeaderText="Descrição" DataField="descricao" SortExpression="descricao" HeaderStyle-Width="300" />
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
            <div class="row">
                <div class="col-md-4">                    
                    <asp:CheckBox ID="chkStatus" runat="server" Text=" Escolhido" />
                </div>
            </div>
            <br />
            <asp:Button ID="btnSalvar" runat="server" Text="Salvar" CssClass="btn" OnClick="btnSalvar_Click"/>
        </asp:View>
    </asp:MultiView>
    <asp:HiddenField ID="hfOperacao" runat="server" />
    <asp:HiddenField ID="hfID" runat="server" />
</asp:Content>
