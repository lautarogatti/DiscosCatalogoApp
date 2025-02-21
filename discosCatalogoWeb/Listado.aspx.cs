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
    }
}