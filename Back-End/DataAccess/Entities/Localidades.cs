using System;
using System.Collections.Generic;

namespace DataAccess.Entities
{
    public partial class Localidades
    {
        public Localidades()
        {
            Clientes = new HashSet<Clientes>();
      
        }

        public int IdLocalidad { get; set; }
        public string NombreLocalidad { get; set; }
        public string CodigoPostal { get; set; }
        public int IdProvincia { get; set; }
        public string UsuarioCreacion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string UsuarioUltimaModificacion { get; set; }
        public DateTime? FechaUltimaModificacion { get; set; }

      
        public virtual ICollection<Clientes> Clientes { get; set; }
     
    }
}
