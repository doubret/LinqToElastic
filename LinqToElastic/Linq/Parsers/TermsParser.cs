namespace LinqToElastic.Linq.Parsers
{
    using System.Linq.Expressions;
    using ElasticApi;

    internal static class TermsParser
    {
        public static TermsDefinition Parse(Expression left, Expression right, string execution = null)
        {
            return new TermsDefinition
            {
                Name = ExpressionParser.ParseNodes(ExpressionType.MemberAccess, ExpressionParser.ParseMember, left, right),
                Value = ExpressionParser.ParseNodes(ExpressionType.Constant, ExpressionParser.ParseConstant<object>, left, right),
                Execution = execution,
            };
        }
    }
}