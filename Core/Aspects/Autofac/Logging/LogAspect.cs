using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using Serilog;
using System;

namespace Core.Aspects.Autofac.Logging
{
    public class LogAspectAttribute : MethodInterceptionAttribute
    {
        private readonly ILogger _logger;
        public LogAspectAttribute()
        {
            _logger = Log.ForContext(GetType());
        }

        protected override void OnBefore(IInvocation invocation)
        {
            _logger.Information(invocation.Method.Name + " started.");

        }
        protected override void OnException(IInvocation invocation, Exception e)
        {
            _logger.Error("While " + invocation.Method.Name + " works something went wrong.");
        }

        protected override void OnSuccess(IInvocation invocation)
        {
            _logger.Information(invocation.Method.Name + " successfully worked");
        }
        protected override void OnAfter(IInvocation invocation)
        {
            _logger.Information(invocation.Method.Name + " has finished working.");
        }
    }
}
