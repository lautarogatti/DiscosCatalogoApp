using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static System.Net.WebRequestMethods;

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
            if (urlImg.Contains(".png") || urlImg.Contains(".jpg"))
            {
                if (validarLinkImg(urlImg))
                {
                    imgThumbnail.ImageUrl = urlImg;
                }
                else
                {
                    imgThumbnail.ImageUrl = "https://dynamoprojects.com/wp-content/uploads/2022/12/no-image.jpg";
                }
            }
        }

        //funcion que valida si el url de la imagen obtiene una respuesta, si recibe alguna retornará true, si no retornará false
        private bool validarLinkImg(string imgUrl)
        {
            try
            {
                WebRequest peticion = WebRequest.Create(imgUrl);
                WebResponse respuesta;
                respuesta = peticion.GetResponse();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


    }
}