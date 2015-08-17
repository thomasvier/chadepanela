using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace chadepanela
{
    public partial class Lista : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
                bindarGrid();
        }

        private void bindarGrid()
        {
            cpEntities db = new cpEntities();
            var listas = (from l in db.lista
                          orderby l.descricao
                          select l).ToList();

            gvLista.DataSource = listas;
            gvLista.DataBind();
        }

        private void alterar()
        {
            cpEntities db = new cpEntities();

            int id = int.Parse(hfID.Value);
            var lista = (from l in db.lista
                         where l.id.Equals(id)
                         select l).FirstOrDefault();

            lista.descricao = txtDescricao.Text;

            db.SaveChanges();
        }

        private void salvar()
        {
            cpEntities db = new cpEntities();
            lista objLista = new lista();

            int id = (from l in db.lista
                      orderby l.id descending
                      select l.id).FirstOrDefault();

            if (id > 0)
                objLista.id = id;
            else
                objLista.id = 1;

            objLista.descricao = txtDescricao.Text;

            db.lista.Add(objLista);
            db.SaveChanges();
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            if (hfTipoOperacao.Value.Equals("I"))
                salvar();
            else if (hfTipoOperacao.Value.Equals("E"))
                alterar();

            bindarGrid();

            mvLista.SetActiveView(vwLista);
        }

        protected void btnInserir_Click(object sender, EventArgs e)
        {
            mvLista.SetActiveView(vwCadastro);
            hfTipoOperacao.Value = "I";
        }

        protected void gvLista_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Editar"))
            {
                cpEntities db = new cpEntities();

                hfTipoOperacao.Value = "E";

                int index = int.TryParse(e.CommandArgument.ToString(), out index) ? index : 0;
                int id = int.TryParse(gvLista.Rows[index].Cells[2].Text, out id) ? id : 0;

                var lista = (from l in db.lista
                             where l.id.Equals(id)
                             select l).FirstOrDefault();

                hfID.Value = lista.id.ToString();
                txtDescricao.Text = lista.descricao;

                mvLista.SetActiveView(vwCadastro);
            }
            else if(e.CommandName.Equals("Excluir"))
            {
                cpEntities db = new cpEntities();

                int index = int.TryParse(e.CommandArgument.ToString(), out index) ? index : 0;
                int id = int.TryParse(gvLista.Rows[index].Cells[2].Text, out id) ? id : 0;

                var lista = (from l in db.lista
                             where l.id.Equals(id)
                             select l).FirstOrDefault();

                db.lista.Remove(lista);
                db.SaveChanges();

                bindarGrid();
            }
        }
    }
}