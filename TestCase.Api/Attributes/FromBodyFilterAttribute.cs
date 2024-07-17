using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using TestCase.Common.Codes;
using TestCase.Common.ExceptionHandling;

namespace TestCase.Api.Attributes
{
    public sealed class FromBodyFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            IEnumerable<ControllerParameterDescriptor> fromBodyActionParameters = context.ActionDescriptor.Parameters.OfType<ControllerParameterDescriptor>()
                                                                                         .Where(p => p.ParameterInfo.GetCustomAttributes(typeof(FromBodyAttribute), false).Length > 0);

            if (fromBodyActionParameters.Any(p => !context.ActionArguments.ContainsKey(p.Name)))
            {
                throw new TestCaseException(ErrorCode.GenericError, "Invalid Request", System.Net.HttpStatusCode.BadRequest);
            }

            base.OnActionExecuting(context);
        }
    }
}
