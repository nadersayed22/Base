using StingRay.Utility.CommonModels;
using StingRay.Utility.CommonOperation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace StingRay.Utility.Converter
{
    public class EnumExtension
    {
        public static string GetNameByValue(Type enumType, string value)
        {
            return Enum.Parse(enumType, value).ToString();
        }
        public static string GetNameByValue(Type enumType, int value)
        {
            return Enum.Parse(enumType, value.ToString()).ToString();
        }
        public static int GetValueByName(Type enumType, string name)
        {
            return (int)Enum.Parse(enumType, name);
        }      
        public static T GetEnumValueFromDescription<T>(string description)
        {
            var type = typeof(T);
            if (!type.IsEnum)
                throw new ArgumentException();
            var fields = type.GetFields();
            var field = fields.SelectMany(f => f.GetCustomAttributes(typeof(DescriptionAttribute), false), (f, a) => new { Field = f, Att = a }).SingleOrDefault(a =>
                ((DescriptionAttribute)a.Att).Description == description);
            return field == null ? default(T) : (T)field.Field.GetRawConstantValue();
        }
        public static T GetEnumByValue<T>(string value)
        {
            return (T)Enum.Parse(typeof(T), value);
        }
        public static string GetNameByValue<T>(string value)
        {
            return Enum.Parse(typeof(T), value).ToString();
        }
        public static int GetValueByName<T>(string name)
        {
            return (int)Enum.Parse(typeof(T), name);
        }
        public static List<SelectListItem> ToList<T>(int selectedValue = 0)
        {
            var type = typeof(T);
            var names = Enum.GetNames(type);
            return (from object name in names
                    let value = Convert.ToInt32(Enum.Parse(type, name.ToString()))
                    select new SelectListItem
                    {
                        Text = name.ToString(),
                        Value = value.ToString(),
                        Selected = selectedValue == value
                    }).ToList();
        }
        public static List<SelectListItem> ToList<T>(string resourceNameSpace, Assembly assembly, int selectedValue = 0)
        {
            var type = typeof(T);
            var names = Enum.GetNames(type);
            return (from object name in names
                    let value = Convert.ToInt32(Enum.Parse(type, name.ToString()))
                    select new SelectListItem
                    {
                        Text = ResourcesReader.GetValue(resourceNameSpace, name.ToString(), assembly),
                        Value = value.ToString(),
                        Selected = selectedValue == value
                    }).ToList();
        }

        public static Dictionary<string, int> ConvertEnumToDictionary(Type type)
        {
            if (!type.IsEnum)
                throw new InvalidOperationException("enum expected");

            var results =
                Enum.GetValues(type).Cast<object>()
                    .ToDictionary(enumValue => enumValue.ToString(), enumValue => (int)enumValue);

            return results;
            //return string.Format("{{ \"{0}\" : {1} }}", type.Name, Newtonsoft.Json.JsonConvert.SerializeObject(results));
        }

        public static IEnumerable<T> EnumToList<T>()
        {
            Type enumType = typeof(T);

            // Can't use generic type constraints on value types,
            // so have to do check like this
            if (enumType.BaseType != typeof(Enum))
                throw new ArgumentException("T must be of type System.Enum");

            Array enumValArray = Enum.GetValues(enumType);
            List<T> enumValList = new List<T>(enumValArray.Length);

            foreach (int val in enumValArray)
            {
                enumValList.Add((T)Enum.Parse(enumType, val.ToString()));
            }

            return enumValList;
        }
        public static IEnumerable<SelectListItem> GetSelectListItems<TEnum>()
        {
            var selectList = new List<SelectListItem>();

            // Get all values of the Industry enum
            var enumValues = Enum.GetValues(typeof(TEnum)) as TEnum[];
            if (enumValues == null)
                return null;

            foreach (var enumValue in enumValues)
            {
                // Create a new SelectListItem element and set its 
                // Value and Text to the enum value and description.
                selectList.Add(new SelectListItem
                {
                    Value = ((int)Enum.Parse(typeof(TEnum), enumValue.ToString())).ToString(),
                    // GetIndustryName just returns the Display.Name value
                    // of the enum - check out the next chapter for the code of this function.
                    Text = GetEnumDescription(enumValue)
                });
            }

            return selectList;
        }
        public static List<SelectListItem> GetSelectListItems<TEnum>(params TEnum[] ignoreList)
        {
            List<SelectListItem> enumList = new List<SelectListItem>();
            var GetValues = Enum.GetValues(typeof(TEnum));
            foreach (TEnum data in GetValues)
            {
                if (!ignoreList.Contains(data))
                {
                    enumList.Add(new SelectListItem
                    {
                        Text = GetEnumDescription(data),
                        Value = ((int)Enum.Parse(typeof(TEnum), data.ToString())).ToString()
                    });
                }
            }

            return enumList;
        }   
        public static List<SelectListItem> ToSelectList<T>(string resourceNameSpace, Assembly assembly, T selectedValue, bool withSelectItem = true)
        {
            Type enumType = typeof(T);
            var names = Enum.GetNames(enumType);
            var values = Enum.GetValues(enumType).Cast<int>().ToList().Select(a => Convert.ChangeType(a, typeof(T))).ToList();
            var selectList = new List<SelectListItem>();
            if (withSelectItem)
                selectList.Add(new SelectListItem { Text = "", Value = "" });
            selectList.AddRange(names.Select((name, index) => new SelectListItem
            {
                Text = ResourcesReader.GetValue(resourceNameSpace, name, assembly),
                Value = values[index].ToString(),
                Selected = (values[index].ToString() == selectedValue.ToString())
            }));
            return selectList;
        }
        public static List<SelectListItem> ToSelectList<T>(Type enumType, int selectedValue = 0, bool withSelectItem = true)
        {
            var names = Enum.GetNames(enumType);
            var values = Enum.GetValues(enumType).Cast<int>().ToList().Select(a => Convert.ChangeType(a, typeof(T))).ToList();
            var selectList = new List<SelectListItem>();
            if (withSelectItem)
                selectList.Add(new SelectListItem { Text = "", Value = "" });
            selectList.AddRange(names.Select((name, index) => new SelectListItem
            {
                Text = name,
                Value = values[index].ToString(),
                Selected = (values[index].ToString() == selectedValue.ToString())
            }));
            return selectList;
        }
        public static List<SelectListItem> ToSelectList<T>(Type enumType, string resourceNameSpace, Assembly assembly, T selectedValue, bool withSelectItem = true)
        {
            var names = Enum.GetNames(enumType);
            var values = Enum.GetValues(enumType).Cast<int>().ToList().Select(a => Convert.ChangeType(a, typeof(T))).ToList();
            var selectList = new List<SelectListItem>();
            if (withSelectItem)
                selectList.Add(new SelectListItem { Text = "", Value = "" });
            selectList.AddRange(names.Select((name, index) => new SelectListItem
            {
                Text = ResourcesReader.GetValue(resourceNameSpace, name, assembly),
                Value = values[index].ToString(),
                Selected = (values[index].ToString() == selectedValue.ToString())
            }));
            return selectList;
        }


        #region Most Used Methods
        public static List<SelectListItem> ToSelectList<T>(int? selectedValue = null, string OptionalItemText = null)
        {
            var selectList = new List<SelectListItem>();
            if (!string.IsNullOrEmpty(OptionalItemText))
                selectList.Add(new SelectListItem { Text = OptionalItemText, Value = "" });
            selectList.AddRange(Enum.GetValues(typeof(T)).Cast<int>().Select(x => new SelectListItem()
            {
                Text = GetDescriptionFromEnumValue(typeof(T), Enum.Parse(typeof(T), x.ToString()).ToString()),//GetEnumDescription(x),
                Value = ((int)x).ToString(),
                Selected = selectedValue == null ? false : (x == selectedValue)
            }).ToList());
            return selectList;
            //Type enumType = typeof(T);
            //var names = Enum.GetNames(enumType);
            //var values = Enum.GetValues(enumType).Cast<int>().ToList().Select(a => Convert.ChangeType(a, typeof(T))).ToList();
            //var selectList = new List<SelectListItem>();
            //if (!string.IsNullOrEmpty(SelectItemText))
            //    selectList.Add(new SelectListItem { Text = SelectItemText, Value = "" });
            //selectList.AddRange(names.Select((name, index) => new SelectListItem
            //{
            //    Text = name,
            //    Value = values[index].ToString(),
            //    Selected = (values[index].ToString() == selectedValue.ToString())
            //}));
            //return selectList;   
        }
        public static List<KeyValueLookup> ToKeyValueLookup<T>(int? selectedValue = null, string OptionalItemText = null)
        {
            var selectList = new List<KeyValueLookup>();
            if (!string.IsNullOrEmpty(OptionalItemText))
                selectList.Add(new KeyValueLookup { Text = OptionalItemText, Value = "" });
            selectList.AddRange(Enum.GetValues(typeof(T)).Cast<int>().Select(x => new KeyValueLookup()
            {
                Text = GetDescriptionFromEnumValue(typeof(T), Enum.Parse(typeof(T), x.ToString()).ToString()),//GetEnumDescription(x),
                Value = ((int)x).ToString(),
                Selected = selectedValue == null ? false : (x == selectedValue)
            }).ToList());
            return selectList; 
        }public static List<KeyValueLookup> ToKeyValueAsStringLookup<T>(int? selectedValue = null, string OptionalItemText = null)
        {
            var selectList = new List<KeyValueLookup>();
            if (!string.IsNullOrEmpty(OptionalItemText))
                selectList.Add(new KeyValueLookup { Text = OptionalItemText, Value = "" });
            selectList.AddRange(Enum.GetValues(typeof(T)).Cast<int>().Select(x => new KeyValueLookup()
            {
                Text = GetDescriptionFromEnumValue(typeof(T), Enum.Parse(typeof(T), x.ToString()).ToString()),//GetEnumDescription(x),
                Value = GetDescriptionFromEnumValue(typeof(T), Enum.Parse(typeof(T), x.ToString()).ToString()),
                Selected = selectedValue == null ? false : (x == selectedValue)
            }).ToList());
            return selectList; 
        }
        public static string GetEnumDescription(Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] attributes =
                (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (attributes != null && attributes.Length > 0)
                return string.IsNullOrEmpty(attributes[0].Description) ? value.ToString() : attributes[0].Description;
            else
                return value.ToString();
        }
        public static string GetEnumDescription<TEnum>(TEnum value)
        {
            var fi = value.GetType().GetField(value.ToString());

            if (fi != null)
            {
                var attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

                if (attributes.Length > 0)
                {
                    return string.IsNullOrEmpty(attributes[0].Description) ? value.ToString() : attributes[0].Description;
                }
            }

            return value.ToString();
        }
        public static string GetDescriptionFromEnumValue(Type enumType, string value)
        {
            var memInfo = enumType.GetMember(value);
            var attributes = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
            if (attributes != null && attributes.Length > 0)
                return string.IsNullOrEmpty(((DescriptionAttribute)attributes[0]).Description) ? value.ToString() : ((DescriptionAttribute)attributes[0]).Description;
            else
                return value.ToString();
        }
        #endregion
    }
}
