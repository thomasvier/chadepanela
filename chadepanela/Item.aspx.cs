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
            bindarListas();
            bindarGrid();
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
        
        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            cpEntities db = new cpEntities();
            item objItem = new item();
            int lista = int.TryParse(ddlLista.SelectedValue, out lista) ? lista : lista;

            int id = (from i in db.item
                      orderby i.id descending
                      select i.id).FirstOrDefault();

            if (id > 0)
                objItem.id = id;
            else 
                objItem.id = 1;

            objItem.descricao = txtDescricao.Text;
            objItem.idLista = lista;

            db.item.Add(objItem);
            db.SaveChanges();

            bindarGrid();

            mvItem.SetActiveView(vwItens);
        }

        protected void btnInserir_Click(object sender, EventArgs e)
        {
            mvItem.SetActiveView(vwCadastro);
            hfOperacao.Value = "I";
        }
    }
}