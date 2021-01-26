using FluentValidation;
using Repository.Entities.Concrete;

namespace Repository.Business.ValidationRules.FluentValidation
{
    public class CountryValidator : AbstractValidator<Country>
    {
        public CountryValidator()
        {
            RuleFor(x => x.Name).NotNull();
            RuleFor(x => x.CodePhone).NotNull();
            RuleFor(x => x.CodeAlpha2).NotNull();

            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Name).Length(2, 64);


            // Examples:
            // RuleFor(x => x.Title).Must(StartWithT);
            // RuleFor(x => x.UnitPrice).GreaterThan(0);
            // RuleFor(x => x.UnitPrice).GreaterThan(0).When(x => x.CategoryId == 1);
            // RuleFor(x => x.Description).NotEmpty().WithMessage("Throw this message");
        }

        //private static bool StartWithT(string arg)
        //{
        //    return arg.StartsWith("A");
        //}
    }
}