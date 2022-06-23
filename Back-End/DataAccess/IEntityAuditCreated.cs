using System;

namespace DataAccess
{
    public interface IEntityAuditCreated
    {
        public string UsuarioCreacion { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}