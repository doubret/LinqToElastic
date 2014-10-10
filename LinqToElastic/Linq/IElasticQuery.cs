namespace LinqToElastic.Linq
{
    using System.Linq;

    public interface IElasticQuery<out T> : IOrderedQueryable<T>
    {
    }
}
