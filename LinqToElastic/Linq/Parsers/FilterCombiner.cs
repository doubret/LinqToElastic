namespace LinqToElastic.Linq.Parsers
{
    using System;
    using System.Collections.Generic;
    using ElasticApi.Types;

    internal static class FilterCombiner
    {
        public static Filter CombineNot(Filter filter)
        {
			var notFilter = filter as NotFilter;

			if (notFilter != null)
			{
				return notFilter.Not;
			}

			return new NotFilter { Not = filter };
        }

        public static Filter CombineAnd(params Filter[] filters)
        {
            return Combine(combinedFilters => new AndFilter { And = combinedFilters }, filter => filter.And, filters);
        }

        public static Filter CombineOr(params Filter[] filters)
        {
            return Combine(combinedFilters => new OrFilter { Or = combinedFilters }, filter => filter.Or, filters);
        }

        private static Filter Combine<TFilter>(Func<List<Filter>, TFilter> combine, Func<TFilter, IEnumerable<Filter>> subFilters, params Filter[] filters)
            where TFilter : Filter
        {
            List<Filter> combinedFilters = new List<Filter>();

            foreach (var filter in filters)
            {
                if (filter != null)
                {
                    if (filter is TFilter)
                    {
                        combinedFilters.AddRange(subFilters(filter as TFilter));
                    }
                    else
                    {
                        combinedFilters.Add(filter);
                    }
                }
            }

            if (combinedFilters.Count == 0)
            {
                return null;
            }
            else if (combinedFilters.Count == 1)
            {
                return combinedFilters[0];
            }
            else
            {
                return combine(combinedFilters);
            }
        }
    }
}
