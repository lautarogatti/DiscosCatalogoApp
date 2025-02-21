using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using dominio;

namespace negocio
{
    public class TipoEdicionService
    {
        public List <TipoEdicion> listar()
        {
			List<TipoEdicion> lista = new List<TipoEdicion>();
			AccesoDatos datos = new AccesoDatos();
			try
			{
				datos.setearConsulta("SELECT Id, Descripcion FROM TIPOSEDICION");
				datos.ejecutarLectura();

				while (datos.Lector.Read())
				{
					TipoEdicion aux = new TipoEdicion();
					aux.Id = (int)datos.Lector["Id"];
					aux.Descripcion = (string)datos.Lector["Descripcion"];

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
    }
}
