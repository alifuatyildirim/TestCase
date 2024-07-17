using System.Globalization;

namespace TestCase.Common.Extensions;

  public static class DateFormatExtensions
    {
        public const string YearFormat = "yyyy";

        public const string ErpDateFormat = "yyyyMMdd";
        
        public const string HourFormat = "HH:mm";
        
        public const string DateOnlyFormat = "yyyy-MM-dd";
        
        public const string ExcelFileDateFormat = "dd.MM.yyyy";

        public const string ShippingDateTimeFormat = "d.M.yyyy HH:mm:ss";

        public const string ApplicationFormDateFormat = "dd-MM-yyyy";

        public static bool IsValidDate(this string? date, string format = DateOnlyFormat) => DateTime.TryParseExact(date, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime _);
 
        public static DateTime? StringToNullableDatetime(this string? value, string format = DateOnlyFormat) => DateTime.TryParseExact(value, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime val) ? (DateTime?)val : null;
        
        public static DateTime? StringToNullableDateOrMaxValue(this string? value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return null;
            }

            bool result = DateTime.TryParseExact(value, DateOnlyFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime val);

            return result ? (DateTime?)val : DateTime.MaxValue;
        }

        public static DateTime? StringToNullableUtcDatetimeISOFormat(this string? value)
        {
            return DateTime.TryParse(value, CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind, out DateTime val) ? (DateTime?)val.ToUniversalTime() : null;
        }

        public static DateTime? ToEndDateWithUtcNextDay(this string? value)
        {
            return value?.Length <= 10
                ? value.StringToNullableUtcDatetimeISOFormat()?.AddDays(1)
                : value.StringToNullableUtcDatetimeISOFormat();
        }

        public static DateTime StringToUtcDateTime(this string value)
        {
            return DateTime.SpecifyKind(DateTime.Parse(value, CultureInfo.InvariantCulture), DateTimeKind.Utc);
        }

        public static DateTime StringToDateTime(this string value)
        {
            return DateTime.Parse(value, CultureInfo.InvariantCulture);
        }
    }