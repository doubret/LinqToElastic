namespace LinqToElastic.Linq.Parsers
{
    using System;
    using System.Linq.Expressions;
    using ElasticApi;
    using ElasticApi.Types;

    internal static class QueryParser
    {
        public static FilteredQuery Parse(Expression node)
        {
            var query = new FilteredQuery { Filtered = new FilteredDefinition() };

            InternalParse(node, query);

            return query;
        }

        private static void InternalParse(Expression node, FilteredQuery query)
        {
            switch (node.NodeType)
            {
                case ExpressionType.Call:
                    Call((MethodCallExpression)node, query);
                    break;
                case ExpressionType.Parameter:
                    break;
                default:
                    throw new Exception(string.Format("not supported : {0}", node.NodeType));
            }
        }

        private static void Call(MethodCallExpression node, FilteredQuery query)
        {
            QueryParser.InternalParse(node.Arguments[0], query);

            Log.WriteLine(string.Format("   -> Call          : {0}", node.Method.Name));

            switch (node.Method.Name)
            {
                case "Where":
                    ParseFilter(node.Arguments[1], query);
                    break;
                case "Query":
                    ParseQuery(node.Arguments[1], query);
                    break;
                default:
                    throw new Exception(string.Format("method not supported : {0}", node.Method.Name));
            }
        }

        private static void ParseFilter(Expression node, FilteredQuery query)
        {
            Log.WriteLine(string.Format("   -> Parse filter  : {0}", node));

            query.Filtered.Filter = FilterCombiner.CombineAnd(query.Filtered.Filter, FilterParser.Parse(ExpressionParser.Strip(node)));
        }

        private static void ParseQuery(Expression node, FilteredQuery query)
        {
            Log.WriteLine(string.Format("   -> Parse query   : {0}", node));

            query.Filtered.Query = QueryParser.Parse(ExpressionParser.Strip(node));
        }
    }
}