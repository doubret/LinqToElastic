namespace LinqToElastic.Linq.Parsers
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using ElasticApi;
    using ElasticApi.Types;

    internal static class SearchParser
    {
        public static SearchBody Parse(Expression node)
        {
            Log.WriteLine("Search parser");
            Log.WriteLine(string.Format("  -> Input tree : {0}", node));

            var evaluated = Evaluate(node);

            Log.WriteLine(string.Format("  -> Evaluated tree : {0}", evaluated));

            var searchBody = new SearchBody();

            InternalParse(evaluated, searchBody);

            return searchBody;
        }

        private static Expression Evaluate(Expression node)
        {
            Log.WriteLine("  -> Evaluation phase ...");

            return new EvaluationVisitor().Visit(node);
        }

        private static void InternalParse(Expression node, SearchBody searchBody)
        {
            switch (node.NodeType)
            {
                case ExpressionType.Call:
                    Call((MethodCallExpression)node, searchBody);
                    break;
                case ExpressionType.Constant:
                    break;
                default:
                    throw new Exception(string.Format("not supported : {0}", node.NodeType));
            }
        }

        private static void Call(MethodCallExpression node, SearchBody searchBody)
        {
            SearchParser.InternalParse(node.Arguments[0], searchBody);

            Log.WriteLine(string.Format("  -> Call           : {0}", node.Method.Name));

            switch (node.Method.Name)
            {
                case "Where":
                    ParseFilter(node.Arguments[1], searchBody);
                    break;
                case "Query":
                    ParseQuery(node.Arguments[1], searchBody);
                    break;
                case "Take":
                    ParseTake(node.Arguments[1], searchBody);
                    break;
                case "Skip":
                    ParseSkip(node.Arguments[1], searchBody);
                    break;
                case "OrderBy":
                case "ThenBy":
                    ParseSort(node.Arguments[1], searchBody, SortDirection.Ascending);
                    break;
                case "OrderByDescending":
                case "ThenByDescending":
                    ParseSort(node.Arguments[1], searchBody, SortDirection.Descending);
                    break;
                case "OrderByScore":
                case "ThenByScore":
                    AddSort(searchBody, "_score", SortDirection.Ascending);
                    break;
                case "OrderByScoreDescending":
                case "ThenByScoreDescending":
                    AddSort(searchBody, "_score", SortDirection.Descending);
                    break;
                default:
                    throw new Exception(string.Format("method not supported : {0}", node.Method.Name));
            }
        }

        private static void ParseFilter(Expression node, SearchBody searchBody)
        {
            Log.WriteLine(string.Format("  -> Parse filter   : {0}", node));

            searchBody.Filter = FilterCombiner.CombineAnd(searchBody.Filter, FilterParser.Parse(ExpressionParser.Strip(node)));
        }

        private static void ParseQuery(Expression node, SearchBody searchBody)
        {
            Log.WriteLine(string.Format("  -> Parse query    : {0}", node));

            searchBody.Query = QueryParser.Parse(ExpressionParser.Strip(node));
         }

        private static void ParseTake(Expression node, SearchBody searchBody)
        {
            Log.WriteLine(string.Format("  -> Parse take     : {0}", node));

            searchBody.Size = ExpressionParser.ParseConstant<int>(node);
        }

        private static void ParseSkip(Expression node, SearchBody searchBody)
        {
            Log.WriteLine(string.Format("  -> Parse skip     : {0}", node));

            searchBody.From = ExpressionParser.ParseConstant<int>(node);
        }

        private static void ParseSort(Expression node, SearchBody searchBody, SortDirection direction)
        {
            Log.WriteLine(string.Format("  -> Parse sort     : {0}", node));

            AddSort(searchBody, ExpressionParser.ParseMember(ExpressionParser.Strip(node)), direction);
        }

        private static void AddSort(SearchBody searchBody, string field, SortDirection direction)
        {
            Log.WriteLine(string.Format("  -> Add sort       : {0} - {1}", field, direction));

            if (searchBody.Sort == null)
            {
                searchBody.Sort = new List<Sort>();
            }

            searchBody.Sort.Add(new Sort { Field = field, Direction = direction });
        }
    }
}