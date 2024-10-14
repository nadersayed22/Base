using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace StingRay.Utility.CommonOperation
{
    public class GenericTypeOperation
    {
        public static void UpdateValueInProperty(object entity,string PropertyName,object value)
        {
            var type = entity.GetType();
            var propertyInfo = type.GetProperty(PropertyName);
            if (propertyInfo != null)
            {
                Type t = Nullable.GetUnderlyingType(propertyInfo.PropertyType) ?? propertyInfo.PropertyType;
                object safeValue = (value == null) ? null : Convert.ChangeType(value, t);
                propertyInfo.SetValue(entity, safeValue, null);
            }
        }
    }
}
