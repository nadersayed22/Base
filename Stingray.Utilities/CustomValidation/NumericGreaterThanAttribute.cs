using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Reflection;
using System.Web.Mvc;

namespace StingRay.Utility.CustomValidation
{
    public class ModelClientValidationNumericLessThanRule : ModelClientValidationRule
    {
        public ModelClientValidationNumericLessThanRule(string errorMessage, object other, bool allowEquality)
        {
            ErrorMessage = errorMessage;
            ValidationType = "numericlessthan";
            ValidationParameters["other"] = other;
            ValidationParameters["allowequality"] = allowEquality;
        }
    }
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true, Inherited = true)]
    public class NumericGreaterThanAttribute : ValidationAttribute, IClientValidatable
    {
        private const string greaterThanErrorMessage = "{0} must be greater than {1}.";
        private const string greaterThanOrEqualToErrorMessage = "{0} must be greater than or equal to {1}.";
        public string OtherProperty { get; private set; }
        private bool allowEquality;
        public bool AllowEquality
        {
            get { return this.allowEquality; }
            set
            {
                this.allowEquality = value;

                // Set the error message based on whether or not
                // equality is allowed
                this.ErrorMessage = (value ? greaterThanOrEqualToErrorMessage : greaterThanErrorMessage);
            }
        }

        public string PropertyName { get; set; }

        public NumericGreaterThanAttribute(string otherProperty)
        : base(greaterThanErrorMessage)
    {
        if (otherProperty == null) { throw new ArgumentNullException("otherProperty"); }
        this.OtherProperty = otherProperty;            
    }
         public override string FormatErrorMessage(string name)
         {
             return String.Format(CultureInfo.CurrentCulture, ErrorMessageString, name, this.PropertyName);
         }
         protected override ValidationResult IsValid(object value, ValidationContext validationContext)
         {
             PropertyInfo otherPropertyInfo = validationContext.ObjectType.GetProperty(OtherProperty);

             if (otherPropertyInfo == null)
             {
                 return new ValidationResult(String.Format(CultureInfo.CurrentCulture, "Could not find a property named {0}.", OtherProperty));
             }

             object otherPropertyValue = otherPropertyInfo.GetValue(validationContext.ObjectInstance, null);

             decimal decValue;
             decimal decOtherPropertyValue;

             // Check to ensure the validating property is numeric
             if (value != null & otherPropertyValue != null)
             {
                 if (!decimal.TryParse(value.ToString(), out decValue))
                 {
                     return
                         new ValidationResult(String.Format(CultureInfo.CurrentCulture, "{0} is not a numeric value.",
                             validationContext.DisplayName));
                 }

                 // Check to ensure the other property is numeric
                 if (!decimal.TryParse(otherPropertyValue.ToString(), out decOtherPropertyValue))
                 {
                     return
                         new ValidationResult(String.Format(CultureInfo.CurrentCulture, "{0} is not a numeric value.",
                             OtherProperty));
                 }

                 // Check for equality
                 if (AllowEquality && decValue == decOtherPropertyValue)
                 {
                     return null;
                 }
                     // Check to see if the value is greater than the other property value
                 else if (decValue > decOtherPropertyValue)
                 {
                     return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
                 }
             }
             return null;
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
             yield return new ModelClientValidationNumericLessThanRule(FormatErrorMessage(metadata.DisplayName), FormatPropertyForClientValidation(this.OtherProperty), this.AllowEquality);
         }
    }
}