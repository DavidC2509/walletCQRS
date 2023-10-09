
using System.Linq.Expressions;
using System.Reflection;
using AuthPermissions.BaseCode.CommonCode;
using AuthPermissions.BaseCode.DataLayer.Classes.SupportTypes;
using AuthPermissions.BaseCode.DataLayer.EfCode;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Template.Command.Interceptor
{
    public static class DataKeyQueryExtensionLocal
    {

        public static void AddSingleTenantShardingQueryFilter(this IMutableEntityType entityType, string tenantId)
        {
            Console.WriteLine("Obtiene las query");

            var parameter = Expression.Parameter(entityType.ClrType);
            var property = Expression.Property(parameter, "DataKey"); // Ajusta el nombre de la propiedad según tu modelo
            var condition = Expression.Equal(property, Expression.Constant(tenantId));
            var lambda = Expression.Lambda(condition, parameter);

            entityType.SetQueryFilter(lambda);
        }


    }
}