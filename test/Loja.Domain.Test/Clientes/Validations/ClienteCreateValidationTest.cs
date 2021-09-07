namespace Loja.Domain.Test.Clientes.Validations
{
    using Loja.Domain.Clientes.Commands;
    using Bogus.Extensions.Brazil;
    using Xunit;
    using System.Collections.Generic;
    using Loja.Domain.Clientes.Validations;
    using Loja.Domain.Core.Models;
    using Loja.Domain.Core.Resources;
    using System.Linq;

    public class ClienteCreateValidationTest
    {
        private readonly ClienteCreateValidation _validator;

        public ClienteCreateValidationTest()
        {
            _validator = new ClienteCreateValidation();
        }

        [Theory(DisplayName = "Deve validar a criação do cliente com sucesso")]
        [MemberData(nameof(CreateCliente))]
        public void InsertClienteWithSuccess(Cliente cliente)
        {
            var command =   new ClienteCreateCommand(cliente.Cpf, cliente.Nome, cliente.Email);
            var result = _validator.Validate(command);

            Assert.True(result.IsValid);
        }

        [Fact(DisplayName = "Deve validar a criação do cliente com erro")]
        public void InsertClienteWithError()
        {
            var command = new ClienteCreateCommand(string.Empty, string.Empty, string.Empty);
            var result = _validator.Validate(command);

            Assert.False(result.IsValid);
            Assert.Equal(3, result.Errors.Count);
        }

        [Theory(DisplayName = "Deve validar a criação do cliente CPF invalido")]
        [InlineData("02332747078")]
        [InlineData("11111111111")]
        [InlineData("0")]
        public void InsertClienteWithCpfInvalid(string cpfInvalid)
        {
            var command = new ClienteCreateCommand(cpfInvalid, "A", "test@test.com");
            var result = _validator.Validate(command);
            var errorMessage = result.Errors.FirstOrDefault().ErrorMessage;

            Assert.False(result.IsValid);
            Assert.Single(result.Errors);
            Assert.Equal(CommonResource.CpfInvalid, errorMessage);
        }

        public static IEnumerable<object[]> CreateCliente()
        {
            var faker = new Bogus.Faker<Cliente>("pt_BR")
                .RuleFor(c => c.Cpf, c => c.Person.Cpf())
                .RuleFor(c => c.Nome, c => c.Random.String2(100))
                .RuleFor(c => c.Email, C => C.Person.Email);

            foreach (var item in faker.Generate(10))
            {
                yield return new[] { item };
            }
        }
    }
}
