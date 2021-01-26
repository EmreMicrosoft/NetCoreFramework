using FluentValidation;

namespace Core.CrossCutting.Validation.FluentValidaiton
{
    public static class ValidationTool
    {
        public static void Validate(IValidator validator, object entity)
        {
            var result = validator.Validate((IValidationContext)entity);

            if (!result.IsValid)
                throw new ValidationException(result.Errors);

        }
    }
}