namespace Loja.Domain.Core.Extension
{
    using System.Text.RegularExpressions;

    public static class StringExtension
    {
        public static string OnlyNumbers(this string value)
        {
            return Regex.Replace(value, "[^a-zA-Z0-9]", string.Empty);
        }
    }
}
