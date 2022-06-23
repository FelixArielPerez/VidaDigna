using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess.Helpers
{
    public static class ModelBuilderExtensions
    {
        public static ModelBuilder EntitiesOfType<T>(this ModelBuilder modelBuilder,
            Action<EntityTypeBuilder> buildAction) where T : class
        {
            return modelBuilder.EntitiesOfType(typeof(T), buildAction);
        }

        public static ModelBuilder EntitiesOfType(this ModelBuilder modelBuilder, Type type,
            Action<EntityTypeBuilder> buildAction)
        {
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
                if (type.IsAssignableFrom(entityType.ClrType))
                    buildAction(modelBuilder.Entity(entityType.ClrType));

            return modelBuilder;
        }
    }
}
