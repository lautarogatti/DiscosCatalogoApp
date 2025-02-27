using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using negocio;

namespace discosCatalogoWeb
{
    public partial class Listado : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DiscoService datos = new DiscoService();
            dgvListadoDiscos.DataSource = datos.listarConSp();
            dgvListadoDiscos.DataBind();
        }

        protected void dgvListadoDiscos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvListadoDiscos.PageIndex = e.NewPageIndex;
            dgvListadoDiscos.DataBind();
        }

        protected void dgvListadoDiscos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow) {
                TableCell commandCell = e.Row.Cells[6];
                foreach (Control control in commandCell.Controls)
                {
                    if(control is WebControl button)
                    {
                        button.CssClass = "btn btn-primary";
                    }
                }
            }
        }

        protected void dgvListadoDiscos_SelectedIndexChanged(object sender, EventArgs e)
        {
            string idSeleccionado = dgvListadoDiscos.SelectedDataKey.Value.ToString();
            Response.Redirect("AltaDisco.aspx?id=" + idSeleccionado);
        }
    }
}