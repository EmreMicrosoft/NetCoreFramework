using System;
using System.Linq;
using Castle.DynamicProxy;
using FluentValidation;
using Core.CrossCutting.Validation.FluentValidaiton;
using Core.Utilities.Intercepters;

namespace Core.Aspects.AutoFac.Validation
{
    public class ValidationInterceptionAspect : MethodInterception
    {
        private readonly Type _validationType;

        public ValidationInterceptionAspect(Type validatortype)
        {
            if (!typeof(IValidator).IsAssignableFrom(validatortype))
                throw new Exception("Wrong Validation Type");

            _validationType = validatortype;
        }


        protected override void OnBefore(IInvocation invocation)
        {

            //var validator =(IValidator) ServiceTool.ServiceProvider.GetService(_validationType);
            var validator = (IValidator)Activator.CreateInstance(_validationType);
            var entityType = _validationType.BaseType.GetGenericArguments()[0];
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType);

            foreach (var entity in entities)
            {
                ValidationTool.Validate(validator, entity);
            }
        }
    }
}