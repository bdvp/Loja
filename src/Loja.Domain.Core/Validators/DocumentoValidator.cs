namespace FluentValidation.Validators
{
    using FluentValidation;
    using FluentValidation.Validators;
    using Loja.Domain.Core.Extension;
    using System.Linq;

    public abstract class DocumentoValidator<T, TProperty> : PropertyValidator<T, TProperty>
    {
        private readonly string errorMessage;

        public DocumentoValidator(string errorMessage)
        {
            this.errorMessage = errorMessage;
        }
        protected override string GetDefaultMessageTemplate(string errorCode)
        {
            return string.IsNullOrWhiteSpace(errorMessage) ? base.GetDefaultMessageTemplate(errorCode) : errorMessage;
        }

        public override bool IsValid(ValidationContext<T> context, TProperty value)
        {
            return value != null || !string.IsNullOrEmpty(value as string);
        }

        protected bool ValidarDigitosIguais(int[] value)
        {
            return value.All(x => x == value.FirstOrDefault());
        }

        protected int[] RetornarNumeros(string value)
        {
            return value.OnlyNumbers().Select(x => (int)char.GetNumericValue(x)).ToArray();
        }
    }
}
