using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObject
{
    public class LocalidadesDTO
    {
        public int IdLocalidad { get; set; }
        public string NombreLocalidad { get; set; }
        public string CodigoPostal { get; set; }
        public int IdProvincia { get; set; }
        public string UsuarioCreacion { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public string UsuarioUltimaModificacion { get; set; }
        public DateTime FechaUltimaModificacion { get; set; }
    }
}
