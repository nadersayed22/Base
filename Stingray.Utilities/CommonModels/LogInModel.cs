using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StingRay.Utility.CommonModels
{
    public class LogInModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string PasswordHashed { get; set; }
        public string ApplicationCode { get; set; }
    }
}