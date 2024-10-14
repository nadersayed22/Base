using StingRay.Utility.CommonModels;
using StingRay.Utility.Resources;
using System.Net;
using System.Web.Mvc;

namespace StingRay.Utility.CustomAttribute
{
    /// <summary>
    /// If an exception occures, sets the exception as handled, and returns an error message as JSON with HttpStatusCode.BadRequest
    /// </summary>
    public class SaveExceptionAttribute : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            if (!filterContext.HttpContext.Request.IsAjaxRequest())
                base.OnException(filterContext);
            else
            {
                filterContext.ExceptionHandled = true;
                filterContext.Result =
                    new JsonCamelCaseResult(new[] { new { Key = "Exception", Errors = new[] { _Messages_Resource.SaveException } } }
                        , JsonRequestBehavior.DenyGet);

                filterContext.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            }
        }
    }
}
