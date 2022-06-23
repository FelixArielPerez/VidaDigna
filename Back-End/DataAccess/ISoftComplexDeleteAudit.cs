using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public interface ISoftComplexDeleteAudit
    {
        public DateTime? FechaUltimaModificacion { get; set; }
        public int? IdEstado { get; set; }
    }
}
