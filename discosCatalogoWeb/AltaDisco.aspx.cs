using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static System.Net.WebRequestMethods;
using dominio;
using negocio;

namespace discosCatalogoWeb
{
    public partial class AltaDisco : System.Web.UI.Page
    {
        List<Estilo> estilos;
        List<TipoEdicion> ediciones;
        protected void Page_Load(object sender, EventArgs e)
        {
            EstiloService eService = new EstiloService();
            TipoEdicionService teService = new TipoEdicionService();
            estilos = eService.listarConSp();
            ediciones = teService.listarConSp();
            if (!IsPostBack)
            {
                ddlEstilo.DataSource = estilos;
                ddlEdicion.DataSource = ediciones;
                ddlEdicion.DataBind();
                ddlEstilo.DataBind();
            }
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

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Disco nuevo = new Disco();
            nuevo.Titulo = txbTitulo.Text;
            nuevo.FechaDeLanzamiento = DateTime.Parse(txbFecha.Text);
            nuevo.CantCanciones = int.Parse(txbCantCanciones.Text);
            nuevo.UrlImagen = txbUrlImagen.Text;
            nuevo.Estilo = new Estilo();
            Estilo eSeleccionado = estilos[ddlEstilo.SelectedIndex];
            nuevo.Estilo.Id = eSeleccionado.Id;
            nuevo.TipoEdicion = new TipoEdicion();
            TipoEdicion teSeleccionado = ediciones[ddlEdicion.SelectedIndex];
            nuevo.TipoEdicion.Id = teSeleccionado.Id;
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