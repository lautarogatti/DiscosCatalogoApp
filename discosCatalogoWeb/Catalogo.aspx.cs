using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using negocio;

namespace discosCatalogoWeb
{
    public partial class Catalogo : System.Web.UI.Page
    {
        public List<Disco> listaDiscos { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["listaDiscos"] != null)
            {
                listaDiscos = (List<Disco>)Session["listaDiscos"];
            }
            else
            {
                DiscoService service = new DiscoService();
                listaDiscos = service.listarConSp();
                Session.Add("listaDiscos", listaDiscos);
            }

            //if (!IsPostBack)
            //{
            //    rptCards.DataSource = listaDiscos;
            //    rptCards.DataBind();
            //}
        }

        //protected void btnDisco_Click(object sender, EventArgs e)
        //{
        //    string discoId = ((Button)sender).CommandArgument;
        //}
    }
}