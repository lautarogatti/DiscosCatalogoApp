using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace discosCatalogoWeb
{
    public partial class AltaDisco : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void txbUrlImagen_TextChanged(object sender, EventArgs e)
        {
            string urlImg = txbUrlImagen.Text;
            imgThubnail.ImageUrl = urlImg;
        }
    }
}