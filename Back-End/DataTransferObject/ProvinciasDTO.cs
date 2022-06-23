using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObject
{
    public class ProvinciasDTO
    {
        public int IdProvincia { get; set; }
        public string NombreProvincia { get; set; }
        public string LetraCpa { get; set; }
        public string CodigoParaProveedores { get; set; }
        public bool SeRealizanVentas { get; set; }
        public decimal PorcentajePlusVariableNetosMed { get; set; }
        public bool PercepDgrproveedores { get; set; }
        public string UsuarioCreacion { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public string UsuarioUltimaModificacion { get; set; }
        public DateTime FechaUltimaModificacion { get; set; }

    }
}
