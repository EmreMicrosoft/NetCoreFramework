using FluentValidation;
using Repository.Entities.Concrete;

namespace Repository.Business.ValidationRules.FluentValidation
{
    public class CityValidator : AbstractValidator<City>
    {
        public CityValidator()
        {
            RuleFor(x => x.Name).NotNull();
            RuleFor(x => x.Name).Length(2, 32);

            RuleFor(x => x.CountryId).NotNull();
        }
    }
}