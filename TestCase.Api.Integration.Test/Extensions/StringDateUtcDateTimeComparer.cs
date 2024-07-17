using System;
using TestCase.Common.Extensions;
using TechTalk.SpecFlow.Assist;
using TestCase.Api.Integration.Test.Setup.CustomValueHandler;

namespace TestCase.Api.Integration.Test.Extensions;

public class StringDateUtcDateTimeComparer : IValueComparer
{
    public bool CanCompare(object actualValue)
    {
        return actualValue is DateTime;
    }

    public bool Compare(string expectedValue, object actualValue)
    {
        if (expectedValue.StartsWith(CurrentDateTimeValueHandler.ComparerKey, StringComparison.OrdinalIgnoreCase) 
            || expectedValue.StartsWith(DateStringValueHandler.ComparerKey, StringComparison.OrdinalIgnoreCase))
        {
            return true;
        }            
            
        DateTime? expected = expectedValue.StringToNullableUtcDatetimeISOFormat();
        if (expected == null)
        {
            return false;
        }

        return expected.Value == (DateTime)actualValue;
    }
}