using System;
using System.Collections.Generic;

namespace DataAccess.Entities
{
    public partial class Estados
    {
        public Estados()
        {
          Clientes = new HashSet<Clientes>();
        }

        public int IdEstado { get; set; }
        public string NombreEstado { get; set; }
        public string TipoEstado { get; set; }
        public string UsuarioCreacion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string UsuarioUltimaModificacion { get; set; }
        public DateTime? FechaUltimaModificacion { get; set; }

 
        public virtual ICollection<Clientes> Clientes { get; set; }
 
    }
}
