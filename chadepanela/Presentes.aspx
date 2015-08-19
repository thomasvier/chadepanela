<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Presentes.aspx.cs" Inherits="chadepanela.Itens" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div style="margin-left: 330px; margin-top: 20px">
        <div style="width:900px">
            <p style="font-size: 14px">Meninas, os itens com o <img src="Imagens/gift.png" class="btnIcon"/> estão esperando para vocês marcarem para me dar. E os que estão no <img src="Imagens/sold.png" class="btnIcon"/> alguém já escolheu.</p>                                    
        </div>
        <asp:GridView ID="gvItens" runat="server" AutoGenerateColumns="false" GridLines="None" Width="900" CssClass="mGrid"
            ShowHeader="false"
            OnPreRender="gvItens_PreRender"
            OnRowCommand="gvItens_RowCommand">
            <Columns>
                <asp:BoundField DataField="id" SortExpression="id" HeaderStyle-CssClass="gridHidden" ItemStyle-CssClass="gridHidden" />
                <asp:BoundField DataField="descricao" SortExpression="descricao" ItemStyle-Width="500" />
                <asp:TemplateField>
                    <ItemTemplate> 
                        <div class="row" style="margin-left: 100px">
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
