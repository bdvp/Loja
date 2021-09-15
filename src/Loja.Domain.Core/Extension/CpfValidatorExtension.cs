namespace FluentValidation
{
    using FluentValidation.Validators;

    public static class CpfValidatorExtension
    {
        public static IRuleBuilderOptions<T, string> CpfIsValid<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder.SetValidator(new CpfValidator<T, string>());
        }
    }
}
