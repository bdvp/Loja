using Loja.Domain.Core.Resources;

namespace FluentValidation.Validators
{
    public class CpfValidator<T, TProperty> : DocumentoValidator<T, TProperty>
    {
        private const int CPFTamanho = 11;
        public override string Name => "CpfValidator";

        internal CpfValidator(string errorMessage)
            : base(errorMessage)
        { }

        public CpfValidator()
            : this(CommonResource.CpfInvalid)
        { }

        public override bool IsValid(ValidationContext<T> context, TProperty value)
        {
            var cpf = value as string ?? string.Empty;

            if (string.IsNullOrEmpty(cpf))
            {
                return false;
            }

            var cpfNumeros = RetornarNumeros(cpf);

            if (!cpfNumeros.Length.Equals(CPFTamanho))
            {
                return false;
            }

            if (ValidarDigitosIguais(cpfNumeros))
            {
                return false;
            }

            return ValidarCpf(cpfNumeros);
        }

        private static bool ValidarCpf(int[] cpf)
        {
            const int PrimeiroDigito = 9;
            const int SegundoDigito = 10;
            int j, i, soma;
            int[] digitoValidador = new int[2];

            for (i = 0; i <= 1; i++)
            {
                soma = 0;
                for (j = 0; j <= PrimeiroDigito - 1 + i; j++)
                {
                    soma += cpf[j] * (SegundoDigito + i - j);
                }

                digitoValidador[i] = (soma * SegundoDigito) % CPFTamanho;
                if (digitoValidador[i] == SegundoDigito)
                {
                    digitoValidador[i] = 0;
                }
            }

            return digitoValidador[0] == cpf[PrimeiroDigito] && digitoValidador[1] == cpf[SegundoDigito];
        }
    }
}
