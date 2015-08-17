using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace chadepanela
{
    public partial class Item : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                bindarListas();
                bindarGrid();
            }
        }

        private void bindarListas()
        {
            cpEntities db = new cpEntities();

            var listas = (from l in db.lista
                          orderby l.descricao
                          select l).ToList();

            ddlLista.DataSource = listas;
            ddlLista.DataTextField = "descricao";
            ddlLista.DataValueField = "id";
            ddlLista.DataBind();
        }

        private void bindarGrid()
        {
            cpEntities db = new cpEntities();

            var itens = (from i in db.item
                         join l in db.lista on i.idLista equals l.id
                         orderby i.descricao
                         select new 
                         {
                            id = i.id,
                            descricao = i.descricao,
                            lista = l.descricao
                         }).ToList();

            gvItens.DataSource = itens;
            gvItens.DataBind();
        }
        
        private void alterar()
        {
            cpEntities db = new cpEntities();

            int id = int.Parse(hfID.Value);

            var item = (from i in db.item
                        where i.id.Equals(id)
                        select i).FirstOrDefault();

            item.descricao = txtDescricao.Text;
            item.idLista = int.Parse(ddlLista.SelectedValue);
            item.status = chkStatus.Checked.Equals(true) ? "T" : "F";

            db.SaveChanges();
        }

        private void salvar()
        {
            cpEntities db = new cpEntities();
            item objItem = new item();
            int lista = int.TryParse(ddlLista.SelectedValue, out lista) ? lista : lista;

            int id = (from i in db.item
                      orderby i.id descending
                      select i.id).FirstOrDefault();
            id++;

            objItem.id = id;

            objItem.descricao = txtDescricao.Text;
            objItem.idLista = lista;
            objItem.status = chkStatus.Checked.Equals(true) ? "T" : "F";

            db.item.Add(objItem);
            db.SaveChanges();
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            if (hfOperacao.Value.Equals("I"))
                salvar();
            else if(hfOperacao.Value.Equals("E"))
                alterar();
            
            bindarGrid();

            mvItem.SetActiveView(vwItens);
        }

        protected void btnInserir_Click(object sender, EventArgs e)
        {
            mvItem.SetActiveView(vwCadastro);
            hfOperacao.Value = "I";
        }

        protected void gvItens_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if(e.CommandName.Equals("Editar"))
            {
                hfOperacao.Value = "E";

                cpEntities db = new cpEntities();

                int index = int.TryParse(e.CommandArgument.ToString(), out index) ? index : 0;
                int id = int.TryParse(gvItens.Rows[index].Cells[2].Text, out id) ? id : 0;

                var item = (from i in db.item
                            where i.id.Equals(id)
                            select i).FirstOrDefault();

                txtDescricao.Text = item.descricao;
                ddlLista.SelectedValue = item.idLista.ToString();
                chkStatus.Checked = item.status.Equals("T") ? true : false;
                hfID.Value = item.id.ToString();

                mvItem.SetActiveView(vwCadastro);
            }
            else if(e.CommandName.Equals("Excluir"))
            {
                cpEntities db = new cpEntities();

                int index = int.TryParse(e.CommandArgument.ToString(), out index) ? index : 0;
                int id = int.TryParse(gvItens.Rows[index].Cells[2].Text, out id) ? id : 0;

                var item = (from i in db.item
                            where i.id.Equals(id)
                            select i).FirstOrDefault();

                db.item.Remove(item);
                db.SaveChanges();

                bindarGrid();
            }
        }
    }
}