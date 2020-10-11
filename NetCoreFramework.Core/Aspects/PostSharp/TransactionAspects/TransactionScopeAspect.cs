using System;
using System.Transactions;
using PostSharp.Aspects;

namespace NetCoreFramework.Core.Aspects.Postsharp.TransactionAspects
{
    [Serializable]
    public class TransactionScopeAspect : OnMethodBoundaryAspect
    {
        private readonly TransactionScopeOption _option;

        public TransactionScopeAspect()
        {
            //using (var scope = new TransactionScope())
            //{
            //    // Send TransactionScopeOption parameters.
            //}
        }

        public TransactionScopeAspect(TransactionScopeOption option)
        {
            _option = option;
        }

        public override void OnEntry(MethodExecutionArgs args)
        {
            args.MethodExecutionTag = new TransactionScope(_option);
        }

        public override void OnSuccess(MethodExecutionArgs args)
        {
            ((TransactionScope)args.MethodExecutionTag).Complete();
        }

        public override void OnExit(MethodExecutionArgs args)
        {
            ((TransactionScope)args.MethodExecutionTag).Dispose();
        }

        // .. and Isolation Levels etc.
    }
}