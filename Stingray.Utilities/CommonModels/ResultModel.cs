using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StingRay.Utility.CommonModels
{
    public class ResultModel
    {
        public bool Success { set; get; }
        public string Message { set; get; }
        public string ReturnData { set; get; }
        public long LogInUserID { set; get; }
        public List<SharedUserDataModel> UsersModels { set; get; }
        public SharedUserDataModel UserModel { set; get; }
    }
}
