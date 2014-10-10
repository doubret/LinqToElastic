namespace LinqToElastic
{
    using ElasticApi;
    using LinqToElastic.Linq;

    public class ElasticContext
    {
        private readonly IConnection connection;

        public ElasticContext(IConnection connection)
        {
            this.connection = connection;
        }

        public ElasticQuery<T> Query<T>(string index, string type)
        {
            return new ElasticQuery<T>(new ElasticQueryProvider(this.connection));
        }
    }
}
