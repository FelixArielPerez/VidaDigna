using System;

namespace DataAccess
{
    public interface IEntityAuditModified
    {
        public string UsuarioUltimaModificacion { get; set; }
        public DateTime? FechaUltimaModificacion { get; set; }
    }
}