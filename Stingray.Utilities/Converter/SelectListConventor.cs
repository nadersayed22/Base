using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace StingRay.Utility.Converter
{
    public static class SelectListConventor
    {
        public static List<SelectListItem> ConvertToSelectList<T>(List<T> list, int selectedValue = 0,
                                                                   string OptionalItemText = null)
        {
            return ConvertToSelectList(list, "Text", "Value", selectedValue, OptionalItemText);
        }

        public static List<SelectListItem> ConvertToSelectList<T>(List<T> list, string textFiled, string valueFiled,
                                                                  int selectedValue = 0, string OptionalItemText = null)
        {
            var selectList = new List<SelectListItem>();
            var type = typeof(T);
            if (!string.IsNullOrEmpty(OptionalItemText))
                selectList.Add(new SelectListItem { Text = OptionalItemText, Value = "" });
            selectList.AddRange(list.Select(item => new SelectListItem
            {
                Text = type.GetProperty(textFiled).GetValue(item, null).ToString(),
                Value = type.GetProperty(valueFiled).GetValue(item, null).ToString(),
                Selected = (type.GetProperty(valueFiled).GetValue(item, null).ToString() == selectedValue.ToString())
            }));
            return selectList;
        }
        public static List<SelectListItem> ConvertToMultiSelectList<T>(List<T> list,
                                                                   List<string> selectedValues = null)
        {
            return ConvertToMultiSelectList(list, "Text", "Value", selectedValues);
        }
        public static List<SelectListItem> ConvertToMultiSelectList<T>(List<T> list,
                                                                  List<int> selectedValues = null)
        {
            return ConvertToMultiSelectList(list, "Text", "Value", selectedValues.Select(p => p.ToString()).ToList());
        }
        public static List<SelectListItem> ConvertToMultiSelectList<T>(List<T> list,
                                                                  List<Guid> selectedValues = null)
        {
            return ConvertToMultiSelectList(list, "Text", "Value", selectedValues.Select(p => p.ToString()).ToList());
        }
        public static List<SelectListItem> ConvertToMultiSelectList<T>(List<T> list, string textFiled, string valueFiled,
                                                                 List<string> selectedValues = null)
        {
            var selectList = new List<SelectListItem>();
            var type = typeof(T);
            selectedValues = selectedValues ?? new List<string>();
            selectList.AddRange(list.Select(item => new SelectListItem
            {
                Text = type.GetProperty(textFiled).GetValue(item, null).ToString(),
                Value = type.GetProperty(valueFiled).GetValue(item, null).ToString(),
                Selected = (selectedValues.Contains(type.GetProperty(valueFiled).GetValue(item, null).ToString()))
            }));
            return selectList;
        }

    }
}
