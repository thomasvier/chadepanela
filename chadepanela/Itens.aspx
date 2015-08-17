<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Itens.aspx.cs" Inherits="chadepanela.Itens" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div style="margin-left: 120px; margin-top: 20px">
        <asp:GridView ID="gvItens" runat="server" AutoGenerateColumns="false" GridLines="None" Width="900" CssClass="mGrid"
            ShowHeader="false"
            OnPreRender="gvItens_PreRender"
            OnRowCommand="gvItens_RowCommand">
            <Columns>
                <asp:BoundField DataField="id" SortExpression="id" HeaderStyle-CssClass="gridHidden" ItemStyle-CssClass="gridHidden" />
                <asp:BoundField DataField="descricao" SortExpression="descricao" />
                <asp:TemplateField>
                    <ItemTemplate> 
                        <div class="row" style="margin-left: 500px">
                            <div class="col-lg-2">
                                <asp:ImageButton ID="btnStatus" runat="server" CommandName="status" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" CssClass="btnIcon" />
                            </div>
                            <div class="col-lg-8">                        
                                <asp:Label ID="lblStatus" runat="server"></asp:Label>
                            </div>
                        </div>                   
                    </ItemTemplate>
                </asp:TemplateField>            
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
