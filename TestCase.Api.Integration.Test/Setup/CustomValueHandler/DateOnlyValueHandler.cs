using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;
using TestCase.Api.Integration.Test.Extensions;
using TechTalk.SpecFlow.Assist;

namespace TestCase.Api.Integration.Test.Setup.CustomValueHandler;

public class DateOnlyValueHandler : IValueComparer, IValueRetriever
{
    internal const string ComparerKey = "DATE_ONLY";

    private const string DateOnlyRegexPattern =
        @"DATE_ONLY(?<local>(_LOCAL)){0,1}(?<amount>[-\+]\d+){0,1}(?<unit>(d|M|y)){0,1}";

    private readonly Regex dateOnlyRegex = new Regex(DateOnlyRegexPattern);

    public bool CanRetrieve(KeyValuePair<string, string> keyValuePair, Type targetType, Type propertyType)
    {
        return dateOnlyRegex.Match(keyValuePair.Value).Success;
    }

    public object? Retrieve(KeyValuePair<string, string> keyValuePair, Type targetType, Type propertyType)
    {
        if (keyValuePair.Value is "<null>" or "null")
        {
            return null;
        }

        Match match = dateOnlyRegex.Match(keyValuePair.Value);

        if (!match.Success)
        {
            return DateOnly.Parse(keyValuePair.Value, CultureInfo.InvariantCulture);
        }

        var dateOnly = match.ToDateOnly();

        return dateOnly;
    }

    public bool CanCompare(object actualValue)
    {
        return actualValue is DateOnly;
    }

    public bool Compare(string expectedValue, object actualValue)
    {
        var actualDateOnly = (DateOnly)actualValue;

        Match match = dateOnlyRegex.Match(expectedValue);

        if (!match.Success)
        {
            return false;
        }

        var expectedDateOnly = match.ToDateOnly();

        return expectedDateOnly == actualDateOnly;
    }
}