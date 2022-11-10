using System.Globalization;
using TimeZoneConverter;

namespace Bliss.Framework.Helpers
{
    public static class DateTimeHelper
    {
        public static DateTimeOffset DataGmtCorreta()
        {
            var tzInfo = TZConvert.GetTimeZoneInfo("America/Cuiaba");
            var convertedTime = TimeZoneInfo.ConvertTime(DateTimeOffset.UtcNow, tzInfo);
            return convertedTime;
        }

        public static bool IsDateTime(string value)
        {
            if (string.IsNullOrEmpty(value) || value == "null")
            {
                return false;
            }

            string[] formats = { "dd/MM/yyyy", "dd-MM-yyyy", "yyyy-MM-dd" };
            return DateTime.TryParseExact(value.Trim(), formats, new CultureInfo("pt-BR"), DateTimeStyles.None, out _);
        }

        public static DateTime? ConvertDateTime(string value)
        {
            if (string.IsNullOrEmpty(value) || value == "null")
            {
                return null;
            }

            string[] formats = { "dd/MM/yyyy", "dd-MM-yyyy", "yyyy-MM-dd" };
            return DateTime.ParseExact(value.Trim(), formats, new CultureInfo("pt-BR"));
        }

        public static string TimeToString(TimeSpan timeSpan)
        {
            return timeSpan.ToString(@"hh\:mm\:ss", new CultureInfo("pT-BR"));
        }

        public static TimeSpan SumTime<TSource>(this IEnumerable<TSource> source, Func<TSource, TimeSpan> selector)
        {
            return source.Select(selector).Aggregate(TimeSpan.Zero, (t1, t2) => t1 + t2);
        }

        public static bool DataValida(params DateTime?[] datas)
        {
            return datas.All(data => data != null && data != DateTime.MinValue && data != DateTime.MaxValue);
        }

        public static bool DataValida(params DateTimeOffset?[] datas)
        {
            return datas.All(data => data != null && data != DateTimeOffset.MinValue && data != DateTimeOffset.MaxValue);
        }

        public static decimal TimeToDecimal(TimeSpan timeSpan)
        {
            decimal horas = (Convert.ToDecimal(timeSpan.Days) * 24) + Convert.ToDecimal(timeSpan.Hours);
            decimal minutos = Convert.ToDecimal(timeSpan.Minutes) / 60;
            decimal segundos = Convert.ToDecimal(timeSpan.Seconds) / 3600;
            return horas + minutos + segundos;
        }

        public static bool IsHoraInvalida(DateTime? data)
        {
            if (data == null)
            {
                return false;
            }

            return data.Value.TimeOfDay > TimeSpan.Zero;
        }

        public static TimeSpan ObterHoras(DateTime? data)
        {
            return data?.TimeOfDay ?? TimeSpan.Zero;
        }

        public static bool DataFimMenorDataInicio(TimeSpan? inicio, TimeSpan? fim)
        {
            return inicio > TimeSpan.Zero && fim > TimeSpan.Zero && fim < inicio;
        }

        public static bool DataFimMenorDataInicio(DateTimeOffset inicio, DateTimeOffset fim)
        {
            return fim.DateTime < inicio.DateTime;
        }

        public static bool IsHoraInicioFimNulaOuZerada(TimeSpan? inicio, TimeSpan? fim)
        {
            return (inicio == null || inicio == TimeSpan.Zero) &&
                (fim == null || fim == TimeSpan.Zero);
        }

        public static bool IsTime(string value)
        {
            return !string.IsNullOrEmpty(value) && TimeSpan.TryParse(value, out _);
        }

        public static bool Between(DateTime? date, DateTime? start, DateTime? end)
        {
            if (!DataValida(date, start, end))
            {
                return false;
            }

            return date >= start && date <= end;
        }

        public static TimeSpan Arredondar24Hr(TimeSpan time)
        {
            return time == new TimeSpan(23, 59, 59) ? new TimeSpan(24, 00, 00) : time;
        }
    }
}
