using System;
using System.Globalization;
using System.Text.RegularExpressions; 

namespace TestCase.Api.Integration.Test.Extensions
{
    public static class ScenarioDateTimeExtensions
    {
        public static DateTime ScenarioDateTime { get; private set; }
        
        public static DateTime ScenarioDateTimeLocal { get; private set; }

        public static void SetScenarioDateTime(DateTime? dateTime = null)
        {
            ScenarioDateTime = dateTime ?? DateTime.UtcNow;
            ScenarioDateTime = ScenarioDateTime.AddTicks(-(ScenarioDateTime.Ticks % TimeSpan.TicksPerSecond));

            ScenarioDateTimeLocal = DateTime.Now;
            ScenarioDateTimeLocal = ScenarioDateTimeLocal.AddTicks(-(ScenarioDateTimeLocal.Ticks % TimeSpan.TicksPerSecond));
        }

        public static DateTime ToDateTime(this Match regexMatch)
        {
            string unit = string.Empty;
            int amount = 0;
            if (!string.IsNullOrEmpty(regexMatch.Groups["amount"].Value))
            {
                amount = int.Parse(regexMatch.Groups["amount"].Value.Trim(), CultureInfo.InvariantCulture);
            }

            if (!string.IsNullOrEmpty(regexMatch.Groups["unit"].Value))
            {
                unit = regexMatch.Groups["unit"].Value.Trim();
            }

            DateTime dateTimeResult = ScenarioDateTime;
            if (!string.IsNullOrEmpty(regexMatch.Groups["local"].Value))
            {
                dateTimeResult = ScenarioDateTimeLocal;
            }

            if (!string.IsNullOrEmpty(regexMatch.Groups["dateonly"].Value))
            {
                dateTimeResult = dateTimeResult.Date;
            }

            switch (unit)
            {
                case "ms":
                    return dateTimeResult.AddMilliseconds(double.Parse(amount.ToString(CultureInfo.InvariantCulture), CultureInfo.InvariantCulture));
                case "s":
                    return dateTimeResult.AddSeconds(amount);
                case "m":
                    return dateTimeResult.AddMinutes(amount);
                case "h":
                    return dateTimeResult.AddHours(amount);
                case "d":
                    return dateTimeResult.AddDays(amount);
                case "M":
                    return dateTimeResult.AddMonths(amount);
                case "y":
                    return dateTimeResult.AddYears(amount);
                default:
                    return dateTimeResult;
            }
        }
        public static DateOnly ToDateOnly(this Match match)
        {
            if (match == null)
            {
                throw new ArgumentNullException(nameof(match));
            }

            var local = match.Groups["local"].Success;
            var amountString = match.Groups["amount"].Value;
            var unitString = match.Groups["unit"].Value;

            var amount = string.IsNullOrEmpty(amountString) ? 0 : int.Parse(amountString);
            var unit = unitString switch
            {
                "d" => amount,
                "M" => amount * 30,
                "y" => amount * 365, 
                _ => throw new ArgumentException($"Invalid unit '{unitString}'"),
            };

            var dateTime = local ? DateTime.Now.AddDays(unit).Date : DateTime.UtcNow.AddDays(unit).Date;

            var dateOnly = new DateOnly(dateTime.Year, dateTime.Month, dateTime.Day);

            return dateOnly;
        }
    }
}
