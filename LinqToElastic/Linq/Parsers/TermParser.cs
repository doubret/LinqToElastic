namespace LinqToElastic.Linq.Parsers
{
    using System.Linq.Expressions;
    using ElasticApi;

    internal static class TermParser
	{
        public static TermDefinition<T> Parse<T>(Expression left, Expression right)
        {
            return new TermDefinition<T>
            {
                Name = ExpressionParser.ParseNodes(ExpressionType.MemberAccess, ExpressionParser.ParseMember, left, right),
                Value = ExpressionParser.ParseNodes(ExpressionType.Constant, ExpressionParser.ParseConstant<T>, left, right),
            };
        }
    }
}