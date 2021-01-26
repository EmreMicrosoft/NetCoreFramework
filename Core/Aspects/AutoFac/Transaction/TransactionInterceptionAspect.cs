using System;
using System.Transactions;
using Castle.DynamicProxy;
using Core.Utilities.Intercepters;

namespace Core.Aspects.AutoFac.Transaction
{
    public class TransactionInterceptionAspect : MethodInterception
    {
        public override void Intercept(IInvocation invocation)
        {
            using var transactionScope = new TransactionScope();
            try
            {
                invocation.Proceed();
                transactionScope.Complete();
            }
            catch (Exception)
            {
                transactionScope.Dispose();
                throw;
            }
        }
    }
}