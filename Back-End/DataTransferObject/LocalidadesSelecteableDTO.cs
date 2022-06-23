using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObject
{
    public class LocalidadesSelecteableDTO
    {
        public int IdLocalidad { get; set; }
        public string NombreLocalidad { get; set; }
        public int IdProvincia { get; set; }
        public string CodigoPostal { get; set; }
    }
}
