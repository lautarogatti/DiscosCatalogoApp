using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using dominio;
using System.Net;

namespace negocio
{
    public class DiscoService
    {
        public List<Disco> listarDiscos(string id = "")
        {
            List<Disco> lista = new List<Disco>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string consulta = "SELECT D.Id IdDisco, D.Titulo, D.FechaLanzamiento, D.CantidadCanciones, D.UrlImagenTapa, E.Id IdEstilo, E.Descripcion Estilo, TE.Id IdEdicion, TE.Descripcion TipoEdicion, D.Activo FROM DISCOS D, ESTILOS E, TIPOSEDICION TE WHERE E.Id = D.IdEstilo AND TE.Id = D.IdTipoEdicion AND D.Activo = 1";
                if (id != "")
                {
                    consulta += " AND D.id = " + id;
                }
                datos.setearConsulta(consulta);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Disco aux = new Disco();
                    aux.Id = (int)datos.Lector["IdDisco"];
                    aux.Titulo = (string)datos.Lector["Titulo"];
                    aux.FechaDeLanzamiento = (DateTime)datos.Lector["FechaLanzamiento"];
                    aux.CantCanciones = (int)datos.Lector["CantidadCanciones"];
                    if (!(datos.Lector["UrlImagenTapa"] is DBNull))
                    {
                        aux.UrlImagen = (string)datos.Lector["UrlImagenTapa"];
                    }
                    aux.Estilo = new Estilo();
                    aux.Estilo.Id = (int)datos.Lector["IdEstilo"];
                    aux.Estilo.Descripcion = (string)datos.Lector["Estilo"];
                    aux.TipoEdicion = new TipoEdicion();
                    aux.TipoEdicion.Id = (int)datos.Lector["IdEdicion"];
                    aux.TipoEdicion.Descripcion = (string)datos.Lector["TipoEdicion"];
                    aux.Activo = (bool)datos.Lector["Activo"];

                    lista.Add(aux);
                }
                return lista;
            }
            catch (Exception)
            {

                throw;
            }
            finally { datos.cerrarConexion(); }
        }

        public List<Disco> listarConSp()
        {
            List<Disco> lista = new List<Disco>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearStoredProcedure("storedListarDiscos");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Disco aux = new Disco();
                    aux.Id = (int)datos.Lector["IdDisco"];
                    aux.Titulo = (string)datos.Lector["Titulo"];
                    aux.FechaDeLanzamiento = (DateTime)datos.Lector["FechaLanzamiento"];
                    aux.CantCanciones = (int)datos.Lector["CantidadCanciones"];
                    if (!(datos.Lector["UrlImagenTapa"] is DBNull))
                    {
                        aux.UrlImagen = (string)datos.Lector["UrlImagenTapa"];
                    }
                    aux.Estilo = new Estilo();
                    aux.Estilo.Id = (int)datos.Lector["IdEstilo"];
                    aux.Estilo.Descripcion = (string)datos.Lector["Estilo"];
                    aux.TipoEdicion = new TipoEdicion();
                    aux.TipoEdicion.Id = (int)datos.Lector["IdEdicion"];
                    aux.TipoEdicion.Descripcion = (string)datos.Lector["TipoEdicion"];
                    aux.Activo = (bool)datos.Lector["Activo"];

                    lista.Add(aux);
                }
                return lista;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void agregar(Disco disco)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("INSERT INTO DISCOS (Titulo, FechaLanzamiento, CantidadCanciones, UrlImagenTapa, IdEstilo, IdTipoEdicion) VALUES ('" + disco.Titulo + "', '" + disco.FechaDeLanzamiento + "', '" + disco.CantCanciones + "', @UrlImgTapa, @idEstilo, @idTipoEdicion)");
                datos.setearParametro("@UrlImgTapa", disco.UrlImagen);
                datos.setearParametro("@idEstilo", disco.Estilo.Id);
                datos.setearParametro("@idTipoEdicion", disco.TipoEdicion.Id);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally { datos.cerrarConexion(); }

        }

        public void agregarConSp(Disco disco)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearStoredProcedure("storedAgregarDisco");
                //nombre de los parametros tienen que ser los mismos que los definidos en el procedimiento almacenado, estan puestos en el mismo orden simplemente para mas organizacion
                datos.setearParametro("@titulo", disco.Titulo);
                datos.setearParametro("@fechaLanz", disco.FechaDeLanzamiento);
                datos.setearParametro("@cantCanciones", disco.CantCanciones);
                datos.setearParametro("@urlImagen", disco.UrlImagen);
                datos.setearParametro("@idEstilo", disco.Estilo.Id);
                datos.setearParametro("@idTipoEdicion", disco.TipoEdicion.Id);

                datos.ejecutarAccion();
            }
            catch (Exception)
            {

                throw;
            }
            finally { datos.cerrarConexion(); }
        }

        public void modificar(Disco disco)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("UPDATE DISCOS set Titulo = @Titulo, FechaLanzamiento = @FechaLanz, CantidadCanciones = @CantCan, UrlImagenTapa = @Img, IdEstilo = @IdEstilo, IdTipoEdicion = @IdEdicion WHERE Id = @IdDisco");
                datos.setearParametro("@Titulo", disco.Titulo);
                datos.setearParametro("@FechaLanz", disco.FechaDeLanzamiento);
                datos.setearParametro("@CantCan", disco.CantCanciones);
                datos.setearParametro("@Img", disco.UrlImagen);
                datos.setearParametro("@IdEstilo", disco.Estilo.Id);
                datos.setearParametro("@IdEdicion", disco.TipoEdicion.Id);
                datos.setearParametro("@IdDisco", disco.Id);

                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally { datos.cerrarConexion(); }
        }

        public void eliminar(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("DELETE FROM DISCOS WHERE Id = @id");
                datos.setearParametro("@id", id);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw  ex;
            }
            finally { datos.cerrarConexion(); }
        }

        public void eliminarLogico(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("");

            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Disco> filtrar(string campo, string criterio, string clave)
        {
            List<Disco> lista = new List<Disco>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string consulta = "SELECT D.Id IdDisco, D.Titulo, D.FechaLanzamiento, D.CantidadCanciones, D.UrlImagenTapa, E.Id IdEstilo, E.Descripcion Estilo, TE.Id IdEdicion, TE.Descripcion TipoEdicion FROM DISCOS D, ESTILOS E, TIPOSEDICION TE WHERE E.Id = D.IdEstilo AND TE.Id = D.IdTipoEdicion AND ";

                switch (campo)
                {
                    case "Nombre":
                        switch (criterio)
                        {
                            case "Comienza con":
                                consulta += "D.Titulo LIKE '" + clave + "%'";
                                break;
                            case "Termina con":
                                consulta += "D.Titulo LIKE '%" + clave + "'";
                                break;
                            case "Igual a":
                                consulta += "D.Titulo LIKE '" + clave + "'";
                                break;
                            case "Contiene":
                                consulta += "D.Titulo LIKE '%" + clave + "%'";
                                break;
                        }
                        break;

                    case "Fecha lanz.":
                        switch (criterio)
                        {
                            case "Anterior al":
                                consulta += "D.FechaLanzamiento < '" + clave + "'";
                                break;
                            case "Posterior al":
                                consulta += "D.FechaLanzamiento > '" + clave + "'";
                                break;
                            case "Igual a":
                                consulta += "D.FechaLanzamiento = '" + clave + "'";
                                break;
                        }
                        break;

                    case "Cant. canciones":
                        switch (criterio)
                        {
                            case "Menor a":
                                consulta += "D.CantidadCanciones < '" + clave + "'";
                                break;
                            case "Mayor a":
                                consulta += "D.CantidadCanciones > '" + clave + "'";
                                break;
                            case "Igual a":
                                consulta += "D.CantidadCanciones = '" + clave + "'";
                                break;
                        }
                        break;
                }

                datos.setearConsulta(consulta);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Disco aux = new Disco();
                    aux.Id = (int)datos.Lector["IdDisco"];
                    aux.Titulo = (string)datos.Lector["Titulo"];
                    aux.FechaDeLanzamiento = (DateTime)datos.Lector["FechaLanzamiento"];
                    aux.CantCanciones = (int)datos.Lector["CantidadCanciones"];
                    if (!(datos.Lector["UrlImagenTapa"] is DBNull))
                    {
                        aux.UrlImagen = (string)datos.Lector["UrlImagenTapa"];
                    }
                    aux.Estilo = new Estilo();
                    aux.Estilo.Id = (int)datos.Lector["IdEstilo"];
                    aux.Estilo.Descripcion = (string)datos.Lector["Estilo"];
                    aux.TipoEdicion = new TipoEdicion();
                    aux.TipoEdicion.Id = (int)datos.Lector["IdEdicion"];
                    aux.TipoEdicion.Descripcion = (string)datos.Lector["TipoEdicion"];

                    lista.Add(aux);
                }
                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
