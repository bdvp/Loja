namespace Loja.Domain.Clientes.Validations
{
    using FluentValidation;
    using Loja.Domain.Clientes.Commands;
    using Loja.Domain.Core.Resources;

    public abstract class ClienteValidation<T> : AbstractValidator<T> where T : ClienteCommand
    {
        protected void ValidateId()
        {
            RuleFor(c => c.Id)
                .GreaterThan(0)
                    .WithMessage(ClienteResource.IdRequired);
        }

        protected void ValidateCpf()
        {
            RuleFor(c => c.Cpf)
                .NotEmpty()
                    .WithMessage(CommonResource.Required)
                .CpfIsValid()
                    .When(c => !string.IsNullOrEmpty(c.Cpf), ApplyConditionTo.CurrentValidator)
                    .WithMessage(CommonResource.CpfInvalid);
        }

        protected void ValidateNome()
        {
            RuleFor(c => c.Nome)
                .NotEmpty()
                    .WithMessage(CommonResource.Required)
                .MaximumLength(100)
                    .WithMessage(CommonResource.MaximumLength);
        }

        protected void ValidateEmail()
        {
            RuleFor(c => c.Email)
                .NotEmpty()
                    .WithMessage(CommonResource.Required)
                .EmailAddress()
                    .When(c => !string.IsNullOrEmpty(c.Email), ApplyConditionTo.CurrentValidator)
                    .WithMessage(CommonResource.EmailInvalid);
        }
    }
}
