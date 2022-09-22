using System;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;

namespace DI.Domain.Helpers
{
    public static class EfExtentions
    {
        public static IOrderedQueryable<T> ObjectSort<T>(this IQueryable<T> entities, Expression<Func<T, object>> expression, SortOrder order = SortOrder.Ascending)
        {
            var unaryExpression = expression.Body as UnaryExpression;
            if (unaryExpression != null)
            {
                var propertyExpression = (MemberExpression)unaryExpression.Operand;
                var parameters = expression.Parameters;

                if (propertyExpression.Type == typeof(int))
                {
                    var newExpression = Expression.Lambda<Func<T, int>>(propertyExpression, parameters);
                    return order == SortOrder.Ascending ? entities.OrderBy(newExpression) : entities.OrderByDescending(newExpression);
                }

                if (propertyExpression.Type == typeof(string))
                {
                    var newExpression = Expression.Lambda<Func<T, string>>(propertyExpression, parameters);
                    return order == SortOrder.Ascending ? entities.OrderBy(newExpression) : entities.OrderByDescending(newExpression);
                }

                throw new NotSupportedException("Object type resolution not implemented for this type @INTELLEGO");
            }
            return entities.OrderBy(expression);
        }
    }
}
