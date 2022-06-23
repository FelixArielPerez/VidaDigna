using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObject
{
    public class ClientesDTO
    {
        public int IdCliente { get; set; }
        public int IdTipoDocumento { get; set; }
        public decimal NumeroDocumento { get; set; }
        public string RazonSocial { get; set; }
        public int IdCategoriaCliente { get; set; }
        public string Direccion { get; set; }
        public int IdLocalidad { get; set; }
        public int IdProvincia { get; set; }
        public int? IdEstado { get; set; }
        public string NombreEstado { get; set; }
        public string Cpa { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public decimal? LimiteSemanalDeDeuda { get; set; }
        public decimal? LimiteTotalDeDeuda { get; set; }
        public string Pkoriginal { get; set; }
        public string UsuarioCreacion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string UsuarioUltimaModificacion { get; set; }
        public DateTime? FechaUltimaModificacion { get; set; }
    
        public bool? TitularDeGrupo { get; set; }
        public object selectedEstados { get; set; }
      
    }
}
