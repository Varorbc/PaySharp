using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Linq.Expressions;

namespace PaySharp.Core
{
    public static class FastActivator
    {
        public static Func<T, TResult> Generate<T, TResult>()
        {
            ConstructorInfo constructorInfo = typeof(TResult).GetConstructor(new Type[] { typeof(T), });
#if DEBUG
            ParameterInfo[] parameters = constructorInfo.GetParameters();
            ParameterExpression parameterExpression = Expression.Parameter(typeof(T), parameters[0].Name);
#else
            ParameterExpression parameterExpression = Expression.Parameter(typeof(T));
#endif
            Expression<Func<T, TResult>> expression = Expression.Lambda<Func<T, TResult>>(
                Expression.New(
                    constructorInfo,
                    parameterExpression),
                parameterExpression);
            Func<T, TResult> functor = expression.Compile();
            return functor;
        }
        
    }
}
