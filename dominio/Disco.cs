using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Disco
    {
        public int Id { get; set; }
        [DisplayName("Título")]
        public string Titulo { get; set; }
        [DisplayName("Fecha De Lanzamiento")]
        public DateTime FechaDeLanzamiento { get; set; }
        [DisplayName("Cant. de Canciones")]
        public int CantCanciones { get; set; }
        public string UrlImagen { get; set; }
        public Estilo Estilo { get; set; }
        [DisplayName("Tipo De Edición")]
        public TipoEdicion TipoEdicion { get; set; }
        public bool Activo { get; set; }
    }
}
