using System;
using System.Collections.Generic;

namespace DataAccess.Entities
{
    public partial class Provincias
    {
        public Provincias()
        {
            Clientes = new HashSet<Clientes>();
      
        }

        public int IdProvincia { get; set; }
        public string NombreProvincia { get; set; }
        public string LetraCpa { get; set; }
        
    
        public string UsuarioCreacion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string UsuarioUltimaModificacion { get; set; }
        public DateTime? FechaUltimaModificacion { get; set; }

      
        public virtual ICollection<Clientes> Clientes { get; set; }
     
      
    }
}
