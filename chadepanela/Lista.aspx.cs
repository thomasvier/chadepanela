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

        protected void btnSalvar_Click(object sender, EventArgs e)
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

            bindarGrid();

            mvLista.SetActiveView(vwLista);
        }

        protected void btnInserir_Click(object sender, EventArgs e)
        {
            mvLista.SetActiveView(vwCadastro);
            hfTipoOperacao.Value = "I";
        }
    }
}