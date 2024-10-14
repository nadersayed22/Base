using StingRay.Utility.CommonModels;
using System;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace StingRay.Utility.CustomAttribute
{
    /// <summary>
    /// If modelState is not Valid, returns the modelState errors as JSON with HttpStatusCode.BadRequest
    /// </summary>
    public class ValidateAjaxAttribute : ActionFilterAttribute
    {
        public string excludedProperties { get; set; }
        public string nameModelKey { get; set; }

        public ValidateAjaxAttribute()
        {
        }

        public ValidateAjaxAttribute(string ExcludedProperties, string NameModelKey)
        {
            excludedProperties = ExcludedProperties;
            nameModelKey = NameModelKey;
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (!filterContext.HttpContext.Request.IsAjaxRequest())
                return;

            var modelState = filterContext.Controller.ViewData.ModelState;

            if (!string.IsNullOrEmpty(excludedProperties))
            {
                var model = filterContext.ActionParameters[nameModelKey];
                if (model != null)
                {
                    var modelType = model.GetType();
                    foreach (var item in excludedProperties.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                    {
                        var propertyInfo = modelType.GetProperty(item);

                        if (propertyInfo != null)
                        {
                            if (propertyInfo.GetValue(model) == null)
                            {
                                modelState.Remove(item);
                            }
                        }

                    }
                }
            }

            if (!modelState.IsValid)
            {
                var errorModel =
                        from x in modelState.Keys
                        where modelState[x].Errors.Count > 0
                        select new
                        {
                            Key = x,
                            Errors = modelState[x].Errors.Select(y => y.ErrorMessage).ToArray()
                        };

                filterContext.Result = new JsonCamelCaseResult(errorModel, JsonRequestBehavior.DenyGet);

                filterContext.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            }
        }
    }
}
