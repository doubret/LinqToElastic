namespace LinqToElastic.Linq.Parsers
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using ElasticApi;
    using ElasticApi.Types;

    internal static class FilterParser
    {
        public static Filter Parse(Expression node)
        {
            switch (node.NodeType)
            {
                case ExpressionType.AndAlso:
                    return AndAlso((BinaryExpression)node);
                case ExpressionType.OrElse:
                    return OrElse((BinaryExpression)node);
                case ExpressionType.Equal:
                    return Equal((BinaryExpression)node);
                case ExpressionType.NotEqual:
                    return NotEqual((BinaryExpression)node);
                case ExpressionType.GreaterThan:
                case ExpressionType.GreaterThanOrEqual:
                case ExpressionType.LessThan:
                case ExpressionType.LessThanOrEqual:
                    return Comparison((BinaryExpression)node);
                case ExpressionType.Not:
                    return Not((UnaryExpression)node);
				case ExpressionType.Call:
                    return Call((MethodCallExpression)node);
            }

            throw new Exception(string.Format("not supported : {0}", node.NodeType));
        }

        private static Filter AndAlso(BinaryExpression node)
        {
            Log.WriteLine(string.Format("    -> AndAlso      : {0}", node));
            Log.WriteLine(string.Format("    -> Left         : {0}", node.Left));
            Log.WriteLine(string.Format("    -> Right        : {0}", node.Right));

            return FilterCombiner.CombineAnd(Parse(node.Left), Parse(node.Right));
        }

        private static Filter OrElse(BinaryExpression node)
        {
            Log.WriteLine(string.Format("    -> OrElse       : {0}", node));
            Log.WriteLine(string.Format("    -> Left         : {0}", node.Left));
            Log.WriteLine(string.Format("    -> Right        : {0}", node.Right));

            return FilterCombiner.CombineOr(Parse(node.Left), Parse(node.Right));
        }

        private static Filter Comparison(BinaryExpression node)
        {
            Log.WriteLine(string.Format("    -> Comparison   : {0} - {1}", node.NodeType, node));
            Log.WriteLine(string.Format("    -> Left         : {0}", node.Left));
            Log.WriteLine(string.Format("    -> Right        : {0}", node.Right));

            return new RangeFilter { Range = RangeParser.Parse(node) };
        }

        private static Filter Equal(BinaryExpression node)
        {
            Log.WriteLine(string.Format("    -> Equal        : {0}", node));
            Log.WriteLine(string.Format("    -> Left         : {0}", node.Left));
            Log.WriteLine(string.Format("    -> Right        : {0}", node.Right));

            return new TermFilter { Term = TermParser.Parse<object>(node.Left, node.Right) };
        }

        private static Filter NotEqual(BinaryExpression node)
        {
            Log.WriteLine(string.Format("    -> NotEqual     : {0}", node));
            Log.WriteLine(string.Format("    -> Left         : {0}", node.Left));
            Log.WriteLine(string.Format("    -> Right        : {0}", node.Right));

			return FilterCombiner.CombineNot(FilterParser.Equal (node));
        }

        private static Filter Not(UnaryExpression node)
        {
            Log.WriteLine(string.Format("    -> Not          : {0}", node));
            Log.WriteLine(string.Format("    -> Operand      : {0}", node.Operand));

			return FilterCombiner.CombineNot(FilterParser.Parse (node.Operand));
        }

        private static Filter Call(MethodCallExpression node)
        {
            Log.WriteLine(string.Format("    -> Call         : {0}", node.Method.Name));

            if (node.Method.DeclaringType == typeof(Enumerable))
            {
                return FilterParser.EnumerableCall(node);
            }

            if (node.Method.DeclaringType == typeof(ElasticMethods))
            {
                return FilterParser.ElasticMethodCall(node);
            }

            throw new Exception("call not supported");
        }

        private static Filter EnumerableCall(MethodCallExpression node)
        {
            switch (node.Method.Name)
            {
                case "Contains":
                    return EnumerableContains(node.Arguments[0], node.Arguments[1]);
                default:
                    throw new Exception(string.Format("enumerable call not supported {0}", node.Method.Name));
            }
        }

        private static Filter EnumerableContains(Expression left, Expression right)
        {
            Log.WriteLine(string.Format("    -> Left         : {0}", left));
            Log.WriteLine(string.Format("    -> Right        : {0}", right));

            if (left is MemberExpression)
            {
                return new TermFilter { Term = TermParser.Parse<object>(left, right) };
            }

            if (right is MemberExpression)
            {
                return new TermsFilter { Terms = TermsParser.Parse(left, right) };
            }

            throw new Exception("invalid call to contains");
        }

        private static Filter ElasticMethodCall(MethodCallExpression node)
        {
            switch (node.Method.Name)
            {
                case "ContainsAll":
                    return ContainsAll(node.Arguments[0], node.Arguments[1]);
                case "ContainsAny":
                    return ContainsAny(node.Arguments[0], node.Arguments[1]);
                case "Exists":
                    return Exists(node.Arguments[0]);
                case "Missing":
                    return Missing(node.Arguments[0]);
                default:
                    throw new Exception(string.Format("elastic method call not supported {0}", node.Method.Name));
            }
        }

        private static Filter ContainsAll(Expression left, Expression right)
        {
            Log.WriteLine(string.Format("    -> Left         : {0}", left));
            Log.WriteLine(string.Format("    -> Right        : {0}", right));

            return new TermsFilter { Terms = TermsParser.Parse(left, right, "and") };
        }

        private static Filter ContainsAny(Expression left, Expression right)
        {
            Log.WriteLine(string.Format("    -> Left         : {0}", left));
            Log.WriteLine(string.Format("    -> Right        : {0}", right));

            return new TermsFilter { Terms = TermsParser.Parse(left, right, "and") };
        }

        private static Filter Exists(Expression node)
        {
            Log.WriteLine(string.Format("    -> Node         : {0}", node));

			return new ExistsFilter { Exists = new ExistsDefinition { Field = ExpressionParser.ParseMember(node) } };
        }

        private static Filter Missing(Expression node)
        {
            Log.WriteLine(string.Format("    -> Node         : {0}", node));

			return new MissingFilter { Missing = new MissingDefinition { Field = ExpressionParser.ParseMember(node) } };
        }
    }
}