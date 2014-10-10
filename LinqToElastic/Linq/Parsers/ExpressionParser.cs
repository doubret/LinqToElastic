namespace LinqToElastic.Linq.Parsers
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    internal static class ExpressionParser
	{
        public static Expression StripQuote(Expression node)
        {
            if (node.NodeType != ExpressionType.Quote)
            {
                throw new Exception("expression is not a quote");
            }

            return (node as UnaryExpression).Operand;
        }

        public static Expression StripLambda(Expression node)
        {
            if (node.NodeType != ExpressionType.Lambda)
            {
                throw new Exception("expression is not a lambda");
            }

            return (node as LambdaExpression).Body;
        }

        public static Expression Strip(Expression node)
        {
            return StripLambda(StripQuote(node));
        }

        public static string ParseMember(Expression node)
        {
            if (node.NodeType != ExpressionType.MemberAccess)
            {
                throw new Exception("expression is not a member access");
            }

            MemberExpression member = node as MemberExpression;

			if (member.Expression == null || member.Expression.NodeType == ExpressionType.Constant || member.Expression.NodeType == ExpressionType.Parameter)
            {
	            return member.Member.Name;
			}

            if (member.Expression.NodeType == ExpressionType.MemberAccess)
            {
	            return ParseMember(member.Expression) + "." + member.Member.Name;
            }

			throw new Exception("parse member not supported expression");
		}

        public static T ParseConstant<T>(Expression node)
        {
            if (node.NodeType != ExpressionType.Constant)
            {
                throw new Exception("expression is not a constant");
            }

            var constant = node as ConstantExpression;

            if (typeof(T).IsAssignableFrom(node.Type) == false)
            {
                throw new Exception(string.Format("constant expression type invalid (expected : {0}, actual : {1})", typeof(T), node.Type));
            }

            return (T)constant.Value;
        }

        public static T ParseNodes<T>(ExpressionType nodeType, Func<Expression, T> parser, params Expression[] nodes)
        {
            var node = nodes.SingleOrDefault(x => x.NodeType == nodeType);

            if (node == null)
            {
                throw new Exception(string.Format("no node of type found: {0}", nodeType));
            }

            return parser(node);
        }

        public static T SingleOrDefault<T>(params Expression[] nodes)
            where T : class
        {
            return nodes.SingleOrDefault(x => x is T) as T;
        }

        public static T FirstOrDefault<T>(params Expression[] nodes)
            where T : class
        {
            return nodes.FirstOrDefault(x => x is T) as T;
        }
    }
}