using System.Reflection;
using System.Resources;
using System.Threading;

namespace StingRay.Utility.CommonOperation
{
    public class ResourcesReader
    {
        public static string GetValue(string fullNameSpace, string key, Assembly assembly = null)
        {
            var resourceManager = new ResourceManager(fullNameSpace, assembly ?? Assembly.GetExecutingAssembly());
            var val = resourceManager.GetString(key);
            return val ?? key;
        }
        public static bool IsArabic
        {
            get { return Thread.CurrentThread.CurrentUICulture.Name.StartsWith("ar"); }
        }
    }
}
