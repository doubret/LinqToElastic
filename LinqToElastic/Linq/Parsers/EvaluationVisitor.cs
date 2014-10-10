namespace LinqToElastic.Linq.Parsers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using ElasticApi;

    internal class EvaluationVisitor : ExpressionVisitor
    {
        private static readonly Type[] doNotEvaluateMembersDeclaredOn = { /*typeof(ElasticFields)*/ };
        private static readonly Type[] doNotEvaluateMethodsDeclaredOn = { typeof(Enumerable), typeof(Queryable), typeof(LinqExtensions), typeof(ElasticMethods) };

        private static readonly IDictionary<ExpressionType, IList<Func<Expression, Expression>>> rewritingRules = new Dictionary<ExpressionType, IList<Func<Expression, Expression>>>();

        static EvaluationVisitor()
        {
            AddRewritingRule<MethodCallExpression>(ExpressionType.Call, EvaluationVisitor.RewriteEqualsMethodCall);
            AddRewritingRule<UnaryExpression>(ExpressionType.Not, EvaluationVisitor.RemoveDoubleNot);
            AddRewritingRule<BinaryExpression>(ExpressionType.Equal, EvaluationVisitor.RewriteEqualWithConstantBool);
            AddRewritingRule<BinaryExpression>(ExpressionType.AndAlso, EvaluationVisitor.RemoveAndWithConstantBool);
            AddRewritingRule<BinaryExpression>(ExpressionType.OrElse, EvaluationVisitor.RemoveOrWithConstantBool);
        }

        private static void AddRewritingRule<TExpression>(ExpressionType type, Func<TExpression, Expression> rule)
            where TExpression : Expression
        {
            if (rewritingRules.ContainsKey(type) == false)
            {
                rewritingRules[type] = new List<Func<Expression, Expression>>();
            }

            rewritingRules[type].Add(x => rule(x as TExpression));
        }

        public override Expression Visit(Expression node)
        {
            if (node == null)
            {
                return null;
            }

            // depth first traversal
            var visited = base.Visit(node);

            // rewrite if needed
            var rewritten = RewriteIfNeeded(visited);

            // evaluate if needed
            var evaluated = EvaluateIfNeeded(rewritten);

            return evaluated;
        }

        private static Expression RewriteEqualsMethodCall(MethodCallExpression node)
        {
            if (node.Method.Name == "Equals")
            {
                return Expression.Equal(node.Object, node.Arguments[0]);
            }

            return node;
        }

        private static Expression RemoveDoubleNot(UnaryExpression node)
        {
            if (node.Operand.NodeType == ExpressionType.Not)
            {
                return (node.Operand as UnaryExpression).Operand;
            }

            return node;
        }

        private static Expression RewriteEqualWithConstantBool(BinaryExpression node)
        {
            if (node.Left.NodeType == ExpressionType.Constant && node.Right.NodeType == ExpressionType.Constant)
            {
                return node;
            }

            var constant = ExpressionParser.SingleOrDefault<ConstantExpression>(node.Left, node.Right);

            if (constant != null)
            {
                if (constant.Type == typeof(bool))
                {
                    var value = (bool)constant.Value;

                    var notConstant = constant == node.Left ? node.Right : node.Left;

                    if (value == false)
                    {
                        return Expression.Not(notConstant);
                    }
                    else
                    {
                        return notConstant;
                    }

                }
            }

            return node;
        }

        private static Expression RemoveAndWithConstantBool(BinaryExpression node)
        {
            var constant = ExpressionParser.SingleOrDefault<ConstantExpression>(node.Left, node.Right);

            if (constant != null)
            {
                if (constant.Type == typeof(bool))
                {
                    var value = (bool)constant.Value;

                    var notConstant = constant == node.Left ? node.Right : node.Left;

                    if (value == false)
                    {
                        throw new Exception("cannot && with false");
                    }
                    else
                    {
                        return notConstant;
                    }

                }
            }

            return node;
        }

        private static Expression RemoveOrWithConstantBool(BinaryExpression node)
        {
            var constant = ExpressionParser.SingleOrDefault<ConstantExpression>(node.Left, node.Right);

            if (constant != null)
            {
                if (constant.Type == typeof(bool))
                {
                    var value = (bool)constant.Value;

                    var notConstant = constant == node.Left ? node.Right : node.Left;

                    if (value)
                    {
                        throw new Exception("cannot || with true");
                    }
                    else
                    {
                        return notConstant;
                    }

                }
            }

            return node;
        }

        private static Expression RewriteIfNeeded(Expression node)
        {
            if (rewritingRules.ContainsKey(node.NodeType))
            {
                foreach (var rule in rewritingRules[node.NodeType])
                {
                    var newNode = rule(node);

                    if (object.ReferenceEquals(node, newNode) == false)
                    {
                        Log.WriteLine("  -> Expression rewrite");
                        Log.WriteLine("     Before         : {0}", node);
                        Log.WriteLine("     After          : {0}", newNode);

                        return newNode;
                    }
                }
            }

            return node;
        }

        private static Expression EvaluateIfNeeded(Expression node)
        {
            if (ShouldEvaluate(node) == true)
            {
                return EvaluateExpression(node);
            }

            return node;
        }

        private static bool ShouldEvaluate(Expression node)
        {
            if (node.NodeType == ExpressionType.MemberAccess)
            {
                var member = node as MemberExpression;

                if (member.Expression == null || member.Expression.NodeType == ExpressionType.Constant)
                {
                    return doNotEvaluateMembersDeclaredOn.Contains(member.Member.DeclaringType) == false;
                }
            }

            if (node.NodeType == ExpressionType.Call)
            {
                return doNotEvaluateMethodsDeclaredOn.Contains(((MethodCallExpression)node).Method.DeclaringType) == false;
            }

            if (node.NodeType == ExpressionType.NewArrayInit)
            {
                return true;
            }

            var binary = node as BinaryExpression;

            if (binary != null && binary.Left.NodeType == ExpressionType.Constant && binary.Right.NodeType == ExpressionType.Constant)
            {
                return true;
            }

            var unary = node as UnaryExpression;

            if (unary != null && unary.Operand.NodeType == ExpressionType.Constant)
            {
                return true;
            }

            return false;
        }

        private static ConstantExpression EvaluateExpression(Expression node)
        {
            var newNode = Expression.Constant(Expression.Lambda(node).Compile().DynamicInvoke(null), node.Type);

            Log.WriteLine("  -> Expression evaluation");
            Log.WriteLine("     Before         : {0}", node);
            Log.WriteLine("     After          : {0}", newNode);

            return newNode;
        }
    }
}
