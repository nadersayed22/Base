using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Web.Mvc;

namespace StingRay.Utility.CustomValidation
{

    public class ModelClientValidationGuidEmptyRule : ModelClientValidationRule
    {
        public ModelClientValidationGuidEmptyRule(string errorMessage)
        {
            ErrorMessage = errorMessage;
            ValidationType = "guidempty";

        }
    }

    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true, Inherited = true)]
    public class GuidEmptyAttribute : ValidationAttribute, IClientValidatable
    {


        public string PropertyName { get; set; }

        public override bool IsValid(object value)
        {
            if (value == null)
                return false ;
            var guid = (Guid) value;
            if (guid == Guid.Empty) return false;
            Guid retNum;

            return Guid.TryParse(Convert.ToString(value), out retNum);
        }

        public override string FormatErrorMessage(string name)
        {
            return String.Format(CultureInfo.CurrentCulture, ErrorMessageString, name, this.PropertyName);
        }

        public static string FormatPropertyForClientValidation(string property)
        {
            if (property == null)
            {
                throw new ArgumentException("Value cannot be null or empty.", "property");
            }
            return "*." + property;
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            yield return new ModelClientValidationGuidEmptyRule(FormatErrorMessage(metadata.DisplayName));
        }
    }


}