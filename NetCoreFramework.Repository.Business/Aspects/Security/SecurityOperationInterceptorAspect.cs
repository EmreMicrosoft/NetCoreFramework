using System.Linq;
using System.Security;
using System.Security.Claims;
using Castle.DynamicProxy;
using NetCoreFramework.Core.Utilities.Intercepters;
using NetCoreFramework.Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;

namespace NetCoreFramework.Repository.Business.Aspects.Security
{
    public class SecurityOperationInterceptorAspect : MethodInterception
    {
        private readonly string _operation;
        private readonly ClaimsPrincipal _claimsPrincipal;

        public SecurityOperationInterceptorAspect(string operation)
        {
            _operation = operation;
            _claimsPrincipal = ServiceTool.ServiceProvider.GetService<ClaimsPrincipal>();
        }


        protected override void OnBefore(IInvocation invocation)
        {
            // Use IHttpContextAccessor if Thread.CurrentPrincipal set value comes NULL from UI.
            // Get ClaimsPrincipal for not being in a dependency. Or a better solution: ClaimsToIdentity
            // ServiceTool.ServiceProvider.GetService<IIdentity>(); is useful for IIdentity.

            if (!_claimsPrincipal.Claims.Any(x => x.Type == ClaimTypes.AuthorizationDecision && x.Value == _operation))
                throw new SecurityException("You are not authorized");
        }
    }
}