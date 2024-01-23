using Newtonsoft.Json.Linq;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace ClinicNest.Domain.Util
{
    public static class ClinicNestFunctions
    {        
        public static List<T> CreateList<T>(params T[] values) => new List<T>(values);

        public static List<List<T>> SplitList<T>(List<T> source, int qtd)
        {
            return source
                .Select((x, i) => new { Index = i, Value = x })
                .GroupBy(x => x.Index / qtd)
                .Select(x => x.Select(v => v.Value).ToList())
                .ToList();
        }
        
        public static CultureInfo SupportedCultures() => new CultureInfo("pt-BR");

        public static TimeZoneInfo SupportedTimeZone()
        {
            TimeZoneInfo timezone;

            try
            {
                timezone = TimeZoneInfo.FindSystemTimeZoneById("America/Sao_Paulo");
            }
            catch
            {
                timezone = TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time");
            }

            return timezone;
        }

        public static bool IsValidEmailAddress(this string address) => address != null && new EmailAddressAttribute().IsValid(address);

       

        public static bool IsValidDocument(string cpfCnpj)
        {
            if (!string.IsNullOrEmpty(cpfCnpj))
                return (IsCpf(cpfCnpj) || IsCnpj(cpfCnpj));
            else
                return false;
        }

        public static bool IsCpf(string cpf)
        {
            if (string.IsNullOrEmpty(cpf))
                return false;

            cpf = cpf.Trim().Replace(".", "").Replace("-", "");

            if (!Regex.IsMatch(cpf, @"^\d{11}$"))
                return false;

            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            for (int j = 0; j < 10; j++)
                if (j.ToString(SupportedCultures()).PadLeft(11, char.Parse(j.ToString(SupportedCultures()))) == cpf)
                    return false;

            string tempCpf = cpf.Substring(0, 9);
            int soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString(SupportedCultures()), SupportedCultures()) * multiplicador1[i];

            int resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            string digito = resto.ToString(SupportedCultures());
            tempCpf = tempCpf + digito;
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString(SupportedCultures()), SupportedCultures()) * multiplicador2[i];

            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = digito + resto.ToString(SupportedCultures());

            return cpf.EndsWith(digito, true, SupportedCultures());
        }

        public static bool IsCnpj(string cnpj)
        {
            if (string.IsNullOrEmpty(cnpj))
                return false;

            cnpj = cnpj.Trim().Replace(".", "").Replace("-", "").Replace("/", "");

            if (!Regex.IsMatch(cnpj, @"^\d{14}$"))
                return false;

            int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

            string tempCnpj = cnpj.Substring(0, 12);
            int soma = 0;

            for (int i = 0; i < 12; i++)
                soma += int.Parse(tempCnpj[i].ToString(SupportedCultures()), SupportedCultures()) * multiplicador1[i];

            int resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            string digito = resto.ToString(SupportedCultures());
            tempCnpj = tempCnpj + digito;
            soma = 0;
            for (int i = 0; i < 13; i++)
                soma += int.Parse(tempCnpj[i].ToString(SupportedCultures()), SupportedCultures()) * multiplicador2[i];

            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = digito + resto.ToString(SupportedCultures());

            return cnpj.EndsWith(digito, StringComparison.InvariantCultureIgnoreCase);
        }
        
        public static Dictionary<string, object> DeserializeAndFlatten(Object obj)
        {
            if (obj == null)
                throw new ArgumentNullException(nameof(obj), $"O parâmetro {nameof(obj)} não pode ser nulo.");

            Dictionary<string, object> dict = new Dictionary<string, object>();
            JToken token = JToken.FromObject(obj);
            FillDictionaryFromJToken(dict, token, "");
            return dict;
        }

        private static void FillDictionaryFromJToken(Dictionary<string, object> dict, JToken token, string prefix)
        {
            if (dict == null)
                throw new ArgumentNullException(nameof(dict), $"O parâmetro {nameof(dict)} não pode ser nulo.");

            if(token == null)
                throw new ArgumentNullException(nameof(token), $"O parâmetro {nameof(token)} não pode ser nulo.");

            if(prefix == null)
                throw new ArgumentNullException(nameof(prefix), $"O parâmetro {nameof(prefix)} não pode ser nulo.");

            switch (token.Type)
            {
                case JTokenType.Object:
                    {
                        foreach (JProperty property in token.Children<JProperty>())
                        {
                            FillDictionaryFromJToken(dict, property.Value, CreatePropertyName(prefix, property.Name));
                        }

                        break;
                    }

                case JTokenType.Array:
                    {
                        int index = 0;

                        foreach (JToken value in token.Children())
                        {
                            FillDictionaryFromJToken(dict, value, CreatePropertyName(prefix, index.ToString(SupportedCultures())));
                            index++;
                        }

                        break;
                    }

                default:
                    {
                        dict.Add(prefix, ((JValue)token).Value);
                        break;
                    }
            }
        }

        private static string CreatePropertyName(string prefix, string name) 
        {
            if (name == null)
                throw new ArgumentNullException(nameof(name), $"O parâmetro {nameof(name)} não pode ser nulo.");

            return string.IsNullOrEmpty(prefix) ? name : $"{prefix}_{name}";
        }

        public static string Base64Encode(string data)
        {
            if (data == null)
                throw new ArgumentNullException(nameof(data));

            return Convert.ToBase64String(Encoding.ASCII.GetBytes(data));
        }

        public static string Base64Decode(string data)
        {
            if (string.IsNullOrEmpty(data))
                throw new ArgumentException($"O parâmetro {nameof(data)} não pode ser nulo ou vazio.");

            data = data.PadRight(data.Length + (4 - data.Length % 4) % 4, '=');
            return Encoding.UTF8.GetString(Convert.FromBase64String(data));
        }

        public static double? FormatarCoordenada(string coordenada)
        {
            if (double.TryParse(coordenada, NumberStyles.Any, CultureInfo.InvariantCulture, out double resultado))
                return resultado;

            return null;
        }
    }
}
