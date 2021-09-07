namespace Loja.Domain.Test.Clientes.Validations
{
    using Loja.Domain.Clientes.Commands;
    using Xunit;
    using System.Collections.Generic;
    using Loja.Domain.Clientes.Validations;
    using Loja.Domain.Core.Models;

    public class ClienteUpdateValidationTest
    {
        private readonly ClienteUpdateValidation _validator;

        public ClienteUpdateValidationTest()
        {
            _validator = new ClienteUpdateValidation();
        }

        [Theory(DisplayName = "Deve validar a atualização do cliente com sucesso")]
        [MemberData(nameof(CreateCliente))]
        public void InsertClienteWithSuccess(Cliente cliente)
        {
            var command = new ClienteUpdateCommand(cliente.Id, cliente.Nome, cliente.Email);
            var result = _validator.Validate(command);

            Assert.True(result.IsValid);
        }

        [Fact(DisplayName = "Deve validar a atualização do cliente com erro")]
        public void InsertClienteWithError()
        {
            var command = new ClienteUpdateCommand(0, string.Empty, string.Empty);
            var result = _validator.Validate(command);

            Assert.False(result.IsValid);
            Assert.Equal(3, result.Errors.Count);
        }

        public static IEnumerable<object[]> CreateCliente()
        {
            var faker = new Bogus.Faker<Cliente>("pt_BR")
                .RuleFor(c => c.Id, c => c.Random.Int(1))
                .RuleFor(c => c.Nome, c => c.Random.String2(100))
                .RuleFor(c => c.Email, C => C.Person.Email);

            foreach (var item in faker.Generate(10))
            {
                yield return new[] { item };
            }
        }
    }
}
