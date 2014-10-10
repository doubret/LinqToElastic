namespace LinqToElastic.Linq
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    public class ElasticQuery<T> : IElasticQuery<T>
    {
        private readonly ElasticQueryProvider provider;
        private readonly Expression expression;

        public ElasticQuery(ElasticQueryProvider provider)
        {
            this.provider = provider;
            expression = Expression.Constant(this);
        }

        public ElasticQuery(ElasticQueryProvider provider, Expression expression)
        {
            if (!typeof(IQueryable<T>).IsAssignableFrom(expression.Type))
                throw new ArgumentOutOfRangeException("expression");

            this.provider = provider;
            this.expression = expression;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return ((IEnumerable<T>)provider.Execute(expression)).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            //return ((IEnumerable)provider.Execute(expression)).GetEnumerator();
            return null;
        }

        public Type ElementType
        {
            get
            {
                return typeof(T);
            }
        }

        public Expression Expression
        {
            get
            {
                return expression;
            }
        }

        public IQueryProvider Provider
        {
            get
            {
                return provider;
            }
        }
    }
}