using System.Net;
using System.Runtime.ExceptionServices;
using TestCase.Common.Codes;
using TestCase.Common.ExceptionHandling;
using TestCase.Common.Mediatr.Exceptions;

namespace TestCase.Api.Extensions
{
    public static class ExceptionDispatchInfoExtensions
    {
        public static TestCaseException MapToTestCaseException<TLogger>(this ExceptionDispatchInfo edi, ILogger<TLogger> logger)
        {
            switch (edi.SourceException)
            {
                case TestCaseException ex:
                    LogLevel logLevel = ex.LogLevel ?? LogLevel.Error;
                    string message = ex.Message;
                    if (!string.IsNullOrEmpty(ex.LogMessage))
                    {
                        message = ex.LogMessage;
                    }
                    logger.Log(logLevel, ex.EventId ?? 0, ex, "A TestCaseException was thrown by the application: {Message}", message);
                    return ex;
                
                case CqrsValidationException validationEx:
                    TestCaseException vEx = new(ErrorCode.InvalidRequest.CreateMessage(validationEx.Message), validationEx.Message, System.Net.HttpStatusCode.BadRequest, logLevel: LogLevel.Information);
                    logger.LogInformation(vEx.EventId ?? 0, vEx, "A CqrsValidationException was thrown by the application: " + vEx.Message);
                    return vEx;

                default:
                    logger.LogError(edi.SourceException, $"An unhandled exception was thrown by the application: {edi.SourceException.Message}");
                    return new TestCaseException(ErrorCode.GenericError, $"An unhandled exception was thrown by the application: {edi.SourceException.Message}", HttpStatusCode.InternalServerError, edi.SourceException);
            }
        }
    }
}