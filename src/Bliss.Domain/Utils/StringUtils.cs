namespace Bliss.Domain.Utils
{
    public static class StringUtils
    {
        public static string JoinHtmlMensagem(IEnumerable<string> mensagem)
        {
            return string.Join("<br>", mensagem);
        }
    }
}
