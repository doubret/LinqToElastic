namespace LinqToElastic
{
	using System;
	using System.Collections.Generic;

    public static class ElasticMethods
	{
        public static bool Exists<TSource>(this TSource source)
        {
            throw BuildException("Exists");
        }

        public static bool Missing<TSource>(this TSource source)
        {
            throw BuildException("Missing");
        }

        public static bool ContainsAny<TSource>(this IEnumerable<TSource> source, params TSource[] items)
        {
            throw BuildException("ContainsAny");
        }

        public static bool ContainsAny<TSource>(this IEnumerable<TSource> source, IEnumerable<TSource> items)
        {
            throw BuildException("ContainsAny");
        }

        public static bool ContainsAll<TSource>(this IEnumerable<TSource> source, params TSource[] items)
        {
            throw BuildException("ContainsAll");
        }

        public static bool ContainsAll<TSource>(this IEnumerable<TSource> source, IEnumerable<TSource> items)
        {
            throw BuildException("ContainsAll");
        }

        public static bool Regexp(string field, string regexp)
        {
            throw BuildException("Regexp");
        }

        public static bool Prefix(string field, string startsWith)
        {
            throw BuildException("Prefix");
        }

        private static Exception BuildException(string method)
        {
            return new Exception(string.Format("The method ElasticMethods.{0} is for mapping queries to Elasticsearch and should not be called directly.", method));
        }
	}
}

