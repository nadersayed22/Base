using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Web;

namespace StingRay.Utility.CustomValidation
{
	public sealed class DateEndAttribute : ValidationAttribute
	{
		private const string DateFormat = "MM/dd/yyyy";
		private const string DefaultErrorMessage = "'{0}' must be a date between {1:d} and {2:d}.";

		//public DateTime MinDate { get; set; }
		//public DateTime MaxDate { get; set; }

		//public DateEndAttribute(string minDate, string maxDate)
		//    : base(DefaultErrorMessage)
		//{
		//    MinDate = ParseDate(minDate);
		//    MaxDate = ParseDate(maxDate);
		//}

		public override bool IsValid(object value)
		{
			if (value == null || !(value is DateTime))
			{
				return true;
			}
			var dateValue = (DateTime)value;
			return dateValue <= DateTime.Now;
		}
		public override string FormatErrorMessage(string name)
		{
			return String.Format(CultureInfo.CurrentCulture, ErrorMessageString,
				name);
		}

		private static DateTime ParseDate(string dateValue)
		{
			return DateTime.ParseExact(dateValue, DateFormat,
	 CultureInfo.InvariantCulture);
		}
	}
}