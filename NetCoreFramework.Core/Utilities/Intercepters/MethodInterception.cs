using System;
using Castle.DynamicProxy;

namespace NetCoreFramework.Core.Utilities.Intercepters
{
    public abstract class MethodInterception : MethodInterceptionBaseAttribute
    {
        protected virtual void OnBefore(IInvocation invocation)
        {
        }

        protected virtual void OnAfter(IInvocation invocation)
        {
        }

        protected virtual void OnException(IInvocation invocation)
        {
        }

        protected virtual void OnSuccess(IInvocation invocation)
        {
        }

        public override void Intercept(IInvocation invocation)
        {
            var isSucces = true;
            OnBefore(invocation);

            try
            {
                invocation.Proceed();
            }
            catch (Exception)
            {
                isSucces = false;
                OnException(invocation);
                throw;
            }
            finally
            {
                if (isSucces)
                {
                    OnSuccess(invocation);
                }
            }

            OnAfter(invocation);
        }
    }
}