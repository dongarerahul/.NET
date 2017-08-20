using System.Web.Mvc;

namespace AutomatedTellerMachine.Controllers
{
    public class MyLoggingFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var request = filterContext.HttpContext.Request;
            //Logger.logRequest(request.UserHostAddress);
            base.OnActionExecuted(filterContext);
        }
    }
}