namespace LinqToElastic.Linq.Parsers
{
	using System;
    using System.Linq.Expressions;
    using ElasticApi;

    internal static class RangeParser
	{
        public static RangeDefinition Parse(BinaryExpression node)
        {
			var field = ExpressionParser.SingleOrDefault<MemberExpression>(node.Left, node.Right);
			var value = ExpressionParser.ParseNodes<object>(ExpressionType.Constant, ExpressionParser.ParseConstant<object>, node.Left, node.Right);

			var criteria = new RangeCriteria();

			if (object.ReferenceEquals(node.Left, field) == true)
			{
				switch(node.NodeType)
				{
	                case ExpressionType.GreaterThan:
	                    criteria.Greater = value;
						break;
	                case ExpressionType.GreaterThanOrEqual:
	                    criteria.GreaterOrEqual = value;
						break;
	                case ExpressionType.LessThan:
	                    criteria.Smaller = value;
						break;
	                case ExpressionType.LessThanOrEqual:
	                    criteria.SmallerOrEqual = value;
						break;
					default:
						throw new Exception("invalid range operator");
				}
			}
			else
			{
				switch(node.NodeType)
				{
	                case ExpressionType.GreaterThan:
	                    criteria.Smaller = value;
						break;
	                case ExpressionType.GreaterThanOrEqual:
	                    criteria.SmallerOrEqual = value;
						break;
	                case ExpressionType.LessThan:
	                    criteria.Greater = value;
						break;
	                case ExpressionType.LessThanOrEqual:
	                    criteria.GreaterOrEqual = value;
						break;
					default:
						throw new Exception("invalid range operator");
				}
			}

            return new RangeDefinition
            {
                Field = ExpressionParser.ParseMember(field),
				Criteria = criteria,
            };
        }
    }
}