using AuthPermissions.BaseCode.CommonCode;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Linq;
using System.Linq.Expressions;
using static System.Linq.Expressions.Expression;

namespace Template.Command.Interceptor
{
    public static class ModelBuilderExtensions
    {
        public static void AddQueryFilters(this ModelBuilder modelBuilder,
            Expression<Func<IDataKeyFilterReadWrite, bool>> tenantFilter)
        {

            var entityTypes = modelBuilder.Model.GetEntityTypes()
                              .Where(et => typeof(IDataKeyFilterReadWrite).IsAssignableFrom(et.ClrType))
                              .ToList();

            foreach (var entityType in entityTypes)
            {

                var parameter = Parameter(entityType.ClrType);
                var multiTenantExpression = PrepareExpression(tenantFilter, entityType, parameter);
                
                entityType.SetQueryFilter(Lambda(multiTenantExpression, parameter));
            }
        }

        private static Expression PrepareExpression<T>(Expression<Func<T, bool>> originalExpression, IMutableEntityType entityType, ParameterExpression parameter)
        {
            if (typeof(T).IsAssignableFrom(entityType.ClrType))
                return ReplacingExpressionVisitor.Replace(originalExpression.Parameters.First(), parameter, originalExpression.Body);
            return originalExpression;
        }
    }
}