using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Project.ApplicationLib.Extensions
{
    public static class UtilityExtensions
    {
        public static Expression<T> Compose<T>(this Expression<T> first, Expression<T> second, Func<Expression, Expression, Expression> merge)
        {
            // build parameter map (from parameters of second to parameters of first)
            var map = first.Parameters.Select((f, i) => new { f, s = second.Parameters[i] }).ToDictionary(p => p.s, p => p.f);

            // replace parameters in the second lambda expression with parameters from the first
            var secondBody = ParameterRebinder.ReplaceParameters(map, second.Body);

            // apply composition of lambda expression bodies to parameters from the first expression 
            return Expression.Lambda<T>(merge(first.Body, secondBody), first.Parameters);
        }

        public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> first, Expression<Func<T, bool>> second)
        {
            return first.Compose(second, Expression.And);
        }

        public static Expression<Func<T, bool>> Or<T>(this Expression<Func<T, bool>> first, Expression<Func<T, bool>> second)
        {
            return first.Compose(second, Expression.Or);
        }

        public static IQueryable<TEntity> OrderBy<TEntity>(this IQueryable<TEntity> source, string orderByProperty, System.ComponentModel.ListSortDirection desc)
        {
            string command = desc == System.ComponentModel.ListSortDirection.Descending ? "OrderByDescending" : "OrderBy";
            var type = typeof(TEntity);
            var property = GetPropertyValue(type, orderByProperty);
            var parameter = Expression.Parameter(type, "p");
            Expression body = parameter;
            foreach (var member in orderByProperty.Split('.'))
            {
                body = Expression.PropertyOrField(body, member);
            }
            var orderByExpression = Expression.Lambda(body, parameter);
            var resultExpression = Expression.Call(typeof(Queryable), command, new Type[] { type, property.PropertyType }, source.Expression, Expression.Quote(orderByExpression));
            return source.Provider.CreateQuery<TEntity>(resultExpression);
        }

        private static System.Reflection.PropertyInfo GetPropertyValue(Type objectType, string propertyName)
        {
            System.Reflection.PropertyInfo propInfo = objectType.GetProperty(propertyName);
            if (propInfo == null && propertyName.Contains('.'))
            {
                string firstProp = propertyName.Substring(0, propertyName.IndexOf('.'));
                propInfo = objectType.GetProperty(firstProp);
                if (propInfo == null)
                {
                    throw new ArgumentException(String.Format("Property {0} is not a valid property of {1}.", firstProp, objectType.ToString()));
                }
                return GetPropertyValue(propInfo.PropertyType, propertyName.Substring(propertyName.IndexOf('.') + 1));
            }
            else { return propInfo; }
        }

        public class ParameterRebinder : ExpressionVisitor
        {
            private readonly Dictionary<ParameterExpression, ParameterExpression> map;

            public ParameterRebinder(Dictionary<ParameterExpression, ParameterExpression> map)
            {
                this.map = map ?? new Dictionary<ParameterExpression, ParameterExpression>();
            }

            public static Expression ReplaceParameters(Dictionary<ParameterExpression, ParameterExpression> map, Expression exp)
            {
                return new ParameterRebinder(map).Visit(exp);
            }

            protected override Expression VisitParameter(ParameterExpression p)
            {
                if (map.TryGetValue(p, out ParameterExpression replacement))
                {
                    p = replacement;
                }
                return base.VisitParameter(p);
            }
        }
    }
}
