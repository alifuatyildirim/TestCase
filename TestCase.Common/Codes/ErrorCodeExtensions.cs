using System.Collections.Concurrent;
using TestCase.Common.Extensions;

namespace TestCase.Common.Codes;

public static class ErrorCodeExtensions
{
    private const string Prefix = "E";
    private static readonly ConcurrentDictionary<string, ErrorCode> Codes = new ConcurrentDictionary<string, ErrorCode>(StringComparer.InvariantCultureIgnoreCase);

    public static string ToCode(this ErrorCode errorCode)
    {
        string code = Prefix + (int)errorCode;
        Codes.TryAdd(code, errorCode);
        return code;
    }

    public static ErrorMessage CreateMessage(this ErrorCode errorCode, params object?[] args)
    {
        return new ErrorMessage(errorCode, errorCode.GetDescription(args));
    }
}