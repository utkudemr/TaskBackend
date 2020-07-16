using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Castle.DynamicProxy;

namespace Core.Utilities.Interceptors
{
    public class AspectInterceptorSelector:IInterceptorSelector
    {
        public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
        {
            //MethodInterceptionBaseAttribute aspect kullanılan metot, sınıflar
             var classAttributes = type.GetCustomAttributes<MethodInterceptionBaseAttribute>//çalıştırlmaya çalışsan sınıf.
                (true).ToList();
            var methodAttributes = type.GetMethod(method.Name)//çalıştırlmaya çalışsan metot.
                .GetCustomAttributes<MethodInterceptionBaseAttribute>(true);
            classAttributes.AddRange(methodAttributes);

            return classAttributes.OrderBy(x => x.Priority).ToArray();
        }
    }
}
