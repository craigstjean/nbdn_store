using System;
using System.Diagnostics;
using Castle.Core.Interceptor;

namespace nothinbutdotnetstore.infrastructure.logging
{
    public class MethodInvocationLogger : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            //start a timer
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            //invoke the method
            invocation.Proceed();
            //stop the timer
            stopwatch.Stop();
            //log the timing
            Log.an.informational(string.Format("The method {0} took {1} to run",invocation.Method.Name,
                stopwatch.ElapsedMilliseconds));
        }
    }
}