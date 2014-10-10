namespace LinqToElastic
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    public static class LinqExtensions
    {
        public static IQueryable<TSource> Query<TSource>(this IQueryable<TSource> source, Expression<Action<IQueryable<TSource>>> inner)
        {
            return CreateQueryMethodCall(source, () => source.Query(inner), inner);
        }

        public static IOrderedQueryable<TSource> OrderByScore<TSource>(this IQueryable<TSource> source)
        {
            return (IOrderedQueryable<TSource>)CreateQueryMethodCall(source, () => source.OrderByScore());
        }

        public static IOrderedQueryable<TSource> OrderByScoreDescending<TSource>(this IQueryable<TSource> source)
        {
            return (IOrderedQueryable<TSource>)CreateQueryMethodCall(source, () => source.OrderByScoreDescending());
        }

        public static IOrderedQueryable<TSource> ThenByScore<TSource>(this IOrderedQueryable<TSource> source)
        {
            return (IOrderedQueryable<TSource>)CreateQueryMethodCall(source, () => source.ThenByScore());
        }

        public static IOrderedQueryable<TSource> ThenByScoreDescending<TSource>(this IOrderedQueryable<TSource> source)
        {
            return (IOrderedQueryable<TSource>)CreateQueryMethodCall(source, () => source.ThenByScoreDescending());
        }

        private static IQueryable<TSource> CreateQueryMethodCall<TSource>(IQueryable<TSource> source, Expression<Func<IQueryable<TSource>>> call, params Expression[] arguments)
        {
            var callExpression = Expression.Call(null, (call.Body as MethodCallExpression).Method, new[] { source.Expression }.Concat(arguments));

            return source.Provider.CreateQuery<TSource>(callExpression);
        }
    }
}
