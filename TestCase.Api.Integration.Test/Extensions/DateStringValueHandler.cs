using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;
using TestCase.Common.Extensions;
using TechTalk.SpecFlow.Assist;

namespace TestCase.Api.Integration.Test.Extensions;

 public class DateStringValueHandler : IValueRetriever, IValueComparer
    {
        internal const string ComparerKey = "DATESTRING";
        private const string DateStringPattern = @"DATESTRING(?<local>[L]){0,1}:(\s*)(?<amount>[-\+]\d+){0,1}(?<unit>(ms|s|m|h|d|M|y)){0,1}(,|\s*)(?<format>(.*))";
        private readonly Regex dateStringRegex = new Regex(DateStringPattern);

        public bool CanCompare(object actualValue)
        {
            if (!(actualValue is string))
            {
                return false;
            }

            return DateTime.TryParseExact(
                       actualValue.ToString(),
                       DateFormatExtensions.ErpDateFormat,
                       CultureInfo.InvariantCulture,
                       DateTimeStyles.None,
                       out DateTime _)
                   || DateTime.TryParseExact(
                       actualValue.ToString(),
                       DateFormatExtensions.DateOnlyFormat,
                       CultureInfo.InvariantCulture,
                       DateTimeStyles.None,
                       out DateTime _)
                   || DateTime.TryParseExact(
                       actualValue.ToString(),
                       DateFormatExtensions.HourFormat,
                       CultureInfo.InvariantCulture,
                       DateTimeStyles.None,
                       out DateTime _)
                   || DateTime.TryParseExact(
                       actualValue.ToString(),
                       DateFormatExtensions.DateOnlyFormat,
                       CultureInfo.InvariantCulture,
                       DateTimeStyles.None,
                       out DateTime _)
                   || DateTime.TryParseExact(
                       actualValue.ToString(),
                       DateFormatExtensions.YearFormat,
                       CultureInfo.InvariantCulture,
                       DateTimeStyles.None,
                       out DateTime _)
                   || DateTime.TryParseExact(
                       actualValue.ToString(),
                       DateFormatExtensions.ShippingDateTimeFormat,
                       CultureInfo.InvariantCulture,
                       DateTimeStyles.None,
                       out DateTime _);
        }

        public bool CanRetrieve(KeyValuePair<string, string> keyValuePair, Type targetType, Type propertyType)
        {
            return this.dateStringRegex.Match(keyValuePair.Value).Success;
        }

        public bool Compare(string expectedValue, object actualValue)
        {
            return expectedValue == actualValue.ToString() || this.ConvertToDateString(expectedValue) == actualValue.ToString();
        }

        public object? Retrieve(KeyValuePair<string, string> keyValuePair, Type targetType, Type propertyType)
        {
            Match match = this.dateStringRegex.Match(keyValuePair.Value);
            if (!match.Success)
            {
                return keyValuePair.Value;
            }

            return this.ConvertToDateString(keyValuePair.Value);
        }

        private string ConvertToDateString(string value)
        {
            Match match = this.dateStringRegex.Match(value);
            if (!match.Success)
            {
                return value;
            }

            DateTime dateTimeResult = match.ToDateTime();

            string format = DateFormatExtensions.DateOnlyFormat;
            if (!string.IsNullOrEmpty(match.Groups["format"].Value))
            {
                format = match.Groups["format"].Value.Trim();
            }

            return dateTimeResult.ToString(format, CultureInfo.InvariantCulture);
        }
    }