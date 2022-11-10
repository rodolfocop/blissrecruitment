using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Serialization;
using Bliss.Framework.Extension;
using Microsoft.AspNetCore.Http;

namespace Bliss.Framework.Helpers
{
    public static class StringHelper
    {
        public static string ConcatChaveValor(string chave, string valor)
        {
            var str = valor.IsNotEmpty() ? $"{chave}: {valor}" : $"{chave} não encontrado.";

            return str;
        }

        public static string ConcatLogConfig<T>(T entidade)
        {
            var str = new StringBuilder();
            str.AppendLine("___________________________________________");
            str.AppendLine($"________{typeof(T).Name}__________");

            foreach (var field in typeof(T).GetFields())
            {
                str.AppendLine(ConcatChaveValor(field.Name, $"{field.GetValue(entidade)}"));
            }

            foreach (var property in typeof(T).GetProperties())
            {
                str.AppendLine(ConcatChaveValor(property.Name, $"{property.GetValue(entidade)}"));
            }

            str.AppendLine("___________________________________________");
            return str.ToString();
        }

        public static string JoinHtmlMensagem(IEnumerable<string> mensagem)
        {
            return string.Join("<br>", mensagem);
        }

        public static bool IsCnpj(string cnpj)
        {
            if (IsNullOrEmpty(cnpj))
            {
                return false;
            }

            cnpj = ApenasNumeros(cnpj.Trim());

            if (cnpj.Length != 14)
            {
                return false;
            }

            var hasCnpj = cnpj.Substring(0, 12);
            var resto = ObterCalculoResto(12, hasCnpj, new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 });

            var digits = resto.ToString();
            hasCnpj = hasCnpj + digits;
            resto = ObterCalculoResto(13, hasCnpj, new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 });

            digits = digits + resto.ToString();
            return cnpj.EndsWith(digits);
        }

        public static bool IsCpf(string numeroDocumento)
        {
            if (IsNullOrEmpty(numeroDocumento))
            {
                return false;
            }

            numeroDocumento = ApenasNumeros(numeroDocumento.Trim());

            if (numeroDocumento.Length != 11)
            {
                return false;
            }

            var hasCpf = numeroDocumento.Substring(0, 9);
            var resto = ObterCalculoResto(9, hasCpf, new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 });

            var digitos = resto.ToString();
            hasCpf = hasCpf + digitos;
            resto = ObterCalculoResto(10, hasCpf, new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 });

            digitos = digitos + resto.ToString();
            return numeroDocumento.EndsWith(digitos);
        }

        public static bool IsEmail(string str)
        {
            return new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$").Match(str).Success;
        }

        public static bool IsNullOrEmpty(string str)
        {
            if (str == "null")
            {
                return true;
            }

            return string.IsNullOrEmpty(str) || string.IsNullOrWhiteSpace(str);
        }

        public static bool IsSomenteNumeros(string str)
        {
            return !IsNullOrEmpty(str) && Regex.IsMatch(str, @"^\d+$");
        }

        public static string ApenasNumeros(string str)
        {
            return string.Join(string.Empty, str.ToCharArray().Where(char.IsDigit));
        }

        public static string RemoverEspacos(string str)
        {
            return str.Replace(" ", "");
        }

        private static int ObterCalculoResto(int digits, string cnpj, int[] multiplicator)
        {
            var sum = 0;
            for (var index = 0; index < digits; index++)
            {
                sum += int.Parse(cnpj[index].ToString()) * multiplicator[index];
            }

            var rest = (sum % 11);
            return rest < 2 ? 0 : (11 - rest);
        }

        public static string FormatCNPJ(string CNPJ)
        {
            return !IsCnpj(CNPJ) ? CNPJ : Convert.ToUInt64(ApenasNumeros(CNPJ)).ToString(@"00\.000\.000\/0000\-00");
        }

        public static string FormatCPF(string CPF)
        {
            if (!IsCpf(CPF))
            {
                return CPF;
            }

            return Convert.ToUInt64(ApenasNumeros(CPF)).ToString(@"000\.000\.000\-00");
        }

        public static bool IsStringPesquisa(string pesquisa)
        {
            if (string.IsNullOrEmpty(pesquisa))
            {
                return false;
            }

            return !DateTimeHelper.IsDateTime(pesquisa) &&
                !IsEmail(pesquisa) &&
                !IsCpf(pesquisa) &&
                !IsCnpj(pesquisa) &&
                !IsNullOrEmpty(pesquisa);
        }

        public static T ConvertXmlToObject<T>(string arquivo) where T : class
        {
            var serialize = new XmlSerializer(typeof(T));

            try
            {
                var xmlArquivo = System.Xml.XmlReader.Create(arquivo);
                return (T)serialize.Deserialize(xmlArquivo);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static T ConvertXmlToObject<T>(Stream arquivo) where T : class
        {
            var serialize = new XmlSerializer(typeof(T));

            try
            {
                var xmlArquivo = System.Xml.XmlReader.Create(arquivo);
                return (T)serialize.Deserialize(xmlArquivo);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static T ConvertXmlToObject<T>(IFormFile file) where T : class
        {
            return ConvertXmlToObject<T>(file.OpenReadStream());
        }

        public static string MaxAddPadLeft(string value, int qtdZeros)
        {
            return PadLeft(string.IsNullOrEmpty(value) ? "1" : $"{Convert.ToInt32(ApenasNumeros(value)) + 1}", qtdZeros);
        }

        public static string PadLeft(string value, int qtdZeros, bool onlyNumbers = true)
        {
            if (string.IsNullOrEmpty(value))
            {
                return value;
            }

            if (onlyNumbers && value.Any(c => !char.IsDigit(c)))
            {
                return value;
            }

            return value.PadLeft(qtdZeros, '0');
        }

        public static string RemoverCaracteresEspeciais(string text, bool upperCase = false)
        {
            if (string.IsNullOrEmpty(text))
                return text;

            var caracteresEspeciais = ObterCaracteresEspeciais();
            StringBuilder sb = new();

            foreach (var t in text)
            {
                sb.Append(t > 255 ? t : caracteresEspeciais[t]);
            }

            return upperCase ? sb.ToString().ToUpper() : sb.ToString();
        }

        private static char[] ObterCaracteresEspeciais()
        {
            var accents = new char[256];

            for (var i = 0; i < 256; i++)
                accents[i] = (char)i;

            accents[(byte)'á'] = accents[(byte)'à'] = accents[(byte)'ã'] = accents[(byte)'â'] = accents[(byte)'ä'] = 'a';
            accents[(byte)'Á'] = accents[(byte)'À'] = accents[(byte)'Ã'] = accents[(byte)'Â'] = accents[(byte)'Ä'] = 'A';

            accents[(byte)'é'] = accents[(byte)'è'] = accents[(byte)'ê'] = accents[(byte)'ë'] = 'e';
            accents[(byte)'É'] = accents[(byte)'È'] = accents[(byte)'Ê'] = accents[(byte)'Ë'] = 'E';

            accents[(byte)'í'] = accents[(byte)'ì'] = accents[(byte)'î'] = accents[(byte)'ï'] = 'i';
            accents[(byte)'Í'] = accents[(byte)'Ì'] = accents[(byte)'Î'] = accents[(byte)'Ï'] = 'I';

            accents[(byte)'ó'] = accents[(byte)'ò'] = accents[(byte)'ô'] = accents[(byte)'õ'] = accents[(byte)'ö'] = 'o';
            accents[(byte)'Ó'] = accents[(byte)'Ò'] = accents[(byte)'Ô'] = accents[(byte)'Õ'] = accents[(byte)'Ö'] = 'O';

            accents[(byte)'ú'] = accents[(byte)'ù'] = accents[(byte)'û'] = accents[(byte)'ü'] = 'u';
            accents[(byte)'Ú'] = accents[(byte)'Ù'] = accents[(byte)'Û'] = accents[(byte)'Ü'] = 'U';

            accents[(byte)'ç'] = 'c';
            accents[(byte)'Ç'] = 'C';

            accents[(byte)'ñ'] = 'n';
            accents[(byte)'Ñ'] = 'N';

            accents[(byte)'ÿ'] = accents[(byte)'ý'] = 'y';
            accents[(byte)'Ý'] = 'Y';

            return accents;
        }
    }
}
