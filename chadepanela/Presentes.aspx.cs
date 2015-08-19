using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace chadepanela
{
    public partial class Itens : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
                bindarGrid();
        }

        private void bindarGrid()
        {
            cpEntities db = new cpEntities();

            var itens = (from i in db.item
                         orderby i.descricao
                         select i).ToList();

            gvItens.DataSource = itens;
            gvItens.DataBind();
        }

        protected void gvItens_PreRender(object sender, EventArgs e)
        {
            cpEntities db = new cpEntities();

            foreach(GridViewRow row in gvItens.Rows)
            {
                int codigo = int.TryParse(row.Cells[0].Text, out codigo) ? codigo : 0;

                var stat = (from i in db.item
                            where i.id.Equals(codigo)
                            select i.status).FirstOrDefault();

                if (stat.Equals("T"))
                {
                    ((ImageButton)row.Cells[2].FindControl("btnStatus")).ImageUrl = "~/Imagens/sold.png";
                    ((ImageButton)row.Cells[2].FindControl("btnStatus")).Enabled = false;
                    ((Label)row.Cells[2].FindControl("lblStatus")).Text = "Alguém já comprou este item.";
                }
                else
                {
                    ((ImageButton)row.Cells[2].FindControl("btnStatus")).ImageUrl = "~/Imagens/gift.png";
                    ((ImageButton)row.Cells[2].FindControl("btnStatus")).Enabled = true;
                    ((Label)row.Cells[2].FindControl("lblStatus")).Text = "Quero dar este item.";
                }
            }
        }

        protected void gvItens_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if(e.CommandName.Equals("status"))
            {
                cpEntities db = new cpEntities();

                int index = int.TryParse(e.CommandArgument.ToString(), out index) ? index : 0;
                int id = int.TryParse(gvItens.Rows[index].Cells[0].Text, out id) ? id : 0;

                var edit = (from i in db.item
                            where i.id.Equals(id)
                            select i).FirstOrDefault();

                if(edit.status.Equals("F"))
                    edit.status = "T";


                db.SaveChanges();

                bindarGrid();
            }
        }
    }
}