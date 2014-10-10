namespace LinqToElastic.Linq
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using ElasticApi;
    using ElasticApi.Requests;
    using LinqToElastic.Linq.Parsers;

    public sealed class ElasticQueryProvider : IQueryProvider
    {
        private readonly IConnection connection;

        public ElasticQueryProvider(IConnection connection)
        {
            this.connection = connection;
        }

        public IQueryable<T> CreateQuery<T>(Expression expression)
        {
            if (!typeof(IQueryable<T>).IsAssignableFrom(expression.Type))
            {
                throw new ArgumentOutOfRangeException("expression");
            }

            return new ElasticQuery<T>(this, expression);
        }

        public IQueryable CreateQuery(Expression expression)
        {
            //var elementType = TypeHelper.GetSequenceElementType(expression.Type);
            //var queryType = typeof(ElasticQuery<>).MakeGenericType(elementType);
            //try
            //{
            //    return (IQueryable)Activator.CreateInstance(queryType, new object[] { this, expression });
            //}
            //catch (TargetInvocationException ex)
            {
                //ExceptionDispatchInfo.Capture(ex.InnerException).Throw();
                return null;  // Never called, as the above code re-throws
            }
        }

        public TResult Execute<TResult>(Expression expression)
        {
            return (TResult)ExecuteInternal(expression);
        }

        /// <inheritdoc/>
        public object Execute(Expression expression)
        {
            return ExecuteInternal(expression);
        }

        private object ExecuteInternal(Expression expression)
        {
            var searchBody = SearchParser.Parse(expression);

            Elastic.PostSearch(connection, new PostSearchRequest { Body = searchBody });

            //var translation = ElasticQueryTranslator.Translate(Mapping, Prefix, expression);
            //var elementType = TypeHelper.GetSequenceElementType(expression.Type);

            //Log.Debug(null, null, "Executing query against type {0}", elementType);

            //try
            //{
            //    var response = AsyncHelper.RunSync(() => requestProcessor.SearchAsync(translation.SearchRequest));
            //    if (response == null)
            //        throw new InvalidOperationException("No HTTP response received.");

            //    return translation.Materializer.Materialize(response);
            //}
            //catch (AggregateException ex)
            {
                //ExceptionDispatchInfo.Capture(ex.InnerException).Throw();
                return null;  // Never called, as the above code re-throws
            }
        }
    }
}
