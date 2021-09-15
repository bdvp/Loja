namespace Loja.Domain.Core.Commands
{
    using FluentValidation.Results;
    using Loja.Domain.Core.ValueObject;
    using MediatR;
    using System;

    public abstract class Command : IRequest<Result>
    {
        public abstract bool IsValid();

        public Command()
        {
            Timestamp = DateTime.Now;
        }

        public DateTime Timestamp { get; }
        public ValidationResult ValidationResult { get; set; }

        protected bool Validate(ValidationResult validationResult)
        {
            ValidationResult = validationResult;
            return validationResult.IsValid;
        }
    }
}
