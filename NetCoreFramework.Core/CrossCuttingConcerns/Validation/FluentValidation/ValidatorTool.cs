using FluentValidation;

namespace NetCoreFramework.Core.CrossCuttingConcerns.Validation.FluentValidation
{
    public class ValidatorTool
    {
        public static void FluentValidate(IValidator validator, object entity)
        {
            var result = validator.Validate((IValidationContext)entity);

            if (result.Errors.Count > 0)
                throw new ValidationException(result.Errors);
        }
    }
}