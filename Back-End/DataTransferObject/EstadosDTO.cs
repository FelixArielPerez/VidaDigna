using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObject
{
    public class EstadosDTO
    {
        public int IdEstado { get; set; }
        public string NombreEstado { get; set; }
        public string UsuarioCreacion { get; set; }
        public string TipoEstado { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string UsuarioUltimaModificacion { get; set; }
        public DateTime? FechaUltimaModificacion { get; set; }
    }
}
