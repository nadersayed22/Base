using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StingRay.Utility.CustomValidation
{
    public class ModelClientValidationCompareDateAttribute : ModelClientValidationRule
    {
        public ModelClientValidationCompareDateAttribute(string errorMessage)
        {
            ErrorMessage = errorMessage;
            ValidationType = "CompareDate";

        }
    }
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true, Inherited = true)]
    public class CompareDate: ValidationAttribute, IClientValidatable
    {

        public CompareDate(params string[] propertyNames)
            {
                this.propertyNames = propertyNames;
            }

        public string[] propertyNames { get; private set; }

            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                var properties = this.propertyNames.Select(validationContext.ObjectType.GetProperty);
                var values = properties.Select(p => p.GetValue(validationContext.ObjectInstance, null)).OfType<DateTime>().ToArray();

                if (values.Length >1)
                {
                    if (values[1] < values[0])
                    {
                        return new ValidationResult(this.FormatErrorMessage(validationContext.DisplayName));
                    }

                        
                }
                return ValidationResult.Success;
            }



            public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
            {
                yield return new ModelClientValidationGuidEmptyRule(FormatErrorMessage(metadata.DisplayName));
            }
    }
}
