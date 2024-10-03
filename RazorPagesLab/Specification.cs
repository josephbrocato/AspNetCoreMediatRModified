using System;
using System.Linq.Expressions;

namespace RazorPagesLab;

public abstract class Specification<T>
{
	public abstract Expression<Func<T, bool>> ToExpression();
}