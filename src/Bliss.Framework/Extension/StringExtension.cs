namespace Bliss.Framework.Extension
{
    public static class StringExtension
    {
        public static bool IsEmpty(this string? texto)
        {
            return texto == null || string.IsNullOrWhiteSpace(texto);
        }

        public static bool IsNotEmpty(this string texto)
        {
            return !texto.IsEmpty();
        }

        public static string QuebrarTexto(this string texto, int tamanho = 60)
        {
            if (texto.IsEmpty())
                return string.Empty;

            return texto.Length > tamanho ? $"{texto.Substring(0, tamanho)}..." : texto;
        }

        public static bool Possui(this string texto, string partial)
        {
            return texto.Contains(partial, StringComparison.InvariantCultureIgnoreCase);
        }
    }
}
