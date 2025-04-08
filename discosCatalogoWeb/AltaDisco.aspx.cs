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
        public bool menuEliminarActivo = false;
        public bool menuDesactivarActivo = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            EstiloService eService = new EstiloService();
            TipoEdicionService teService = new TipoEdicionService();
            estilos = eService.listarConSp();
            ediciones = teService.listarConSp();
            if (!IsPostBack)
            {
                ddlEstilo.DataSource = estilos;
                ddlEstilo.DataTextField = "Descripcion";
                ddlEstilo.DataValueField = "Id";
                ddlEdicion.DataSource = ediciones;
                ddlEdicion.DataTextField = "Descripcion";
                ddlEdicion.DataValueField = "Id";
                ddlEdicion.DataBind();
                ddlEstilo.DataBind();

                if (Request.QueryString["id"] != null)
                {
                    DiscoService service = new DiscoService();
                    Disco seleccionado = service.listarDiscos(Request.QueryString["id"])[0];

                    txbTitulo.Text = seleccionado.Titulo;
                    //en algunos navegadores puede no mostrar la fecha ya que es un problema de compatibilidad de lectura entre navegadores, posiblemente la mejor solucion sea utilizar una caja de texto sin el tipo date
                    txbFecha.Text = seleccionado.FechaDeLanzamiento.Date.ToString("yyyy-MM-dd");
                    txbCantCanciones.Text = seleccionado.CantCanciones.ToString();
                    txbUrlImagen.Text = seleccionado.UrlImagen;
                    //posiblemente haya que validar esta linea de codigo para hacer una validacion antes de cargar la imagen
                    imgThumbnail.ImageUrl = seleccionado.UrlImagen;
                    ddlEstilo.SelectedValue = seleccionado.Estilo.Id.ToString();
                    ddlEdicion.SelectedValue = seleccionado.TipoEdicion.Id.ToString();
                    btnAgregar.Text = "Modificar";
                }
            }
        }

        //evento que se encarga de cargar y mostrar la imagen en el formulario utilizando la url facilitada por el usuario si es que esta es una url válida, sino mostrara una imagen de error
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
            try
            {
                DiscoService service = new DiscoService();
                Disco nuevo = new Disco();
                nuevo.Titulo = txbTitulo.Text;
                nuevo.FechaDeLanzamiento = DateTime.Parse(txbFecha.Text);
                nuevo.CantCanciones = int.Parse(txbCantCanciones.Text);
                nuevo.UrlImagen = txbUrlImagen.Text;
                nuevo.Estilo = new Estilo();
                nuevo.Estilo.Id = int.Parse(ddlEstilo.SelectedItem.Value);
                nuevo.TipoEdicion = new TipoEdicion();
                nuevo.TipoEdicion.Id = int.Parse(ddlEdicion.SelectedItem.Value);
                if (Request.QueryString["id"] != null)
                {
                    nuevo.Id = int.Parse(Request.QueryString["id"]);
                    service.modificar(nuevo);
                }
                else
                {
                    service.agregarConSp(nuevo);
                }
                Response.Redirect("Listado.aspx", false);
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                throw;
            }
        }

        protected void btnMenuEliminar_Click(object sender, EventArgs e)
        {
            if (!menuEliminarActivo)
            {
                menuEliminarActivo = true;
            }
            else
            {
                menuEliminarActivo = false;
            }
        }
        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            if (ckbEliminarConfirmacion.Checked)
            {
                try
                {
                    DiscoService service = new DiscoService();
                    service.eliminar(int.Parse(Request.QueryString["id"]));
                    Response.Redirect("Listado.aspx", false);
                }
                catch (Exception ex)
                {
                    Session.Add("Error", ex);
                    throw;
                }
            }
        }
        protected void btnMenuDesactivar_Click(object sender, EventArgs e)
        {
            if (!menuDesactivarActivo)
            {
                menuDesactivarActivo = true;
            }
            else
            {
                menuDesactivarActivo = false;
            }
        }
        protected void btnDesactivar_Click(object sender, EventArgs e)
        {
            DiscoService service = new DiscoService();
            service.eliminarLogico(int.Parse(Request.QueryString["id"]));
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