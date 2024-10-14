using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Base.Models
{
	public class LoginModel
	{
		public int UserType { get; set; }
		public string Username { get; set; }
		public string Password { get; set; }
		public string ReturnURL { get; set; }
		public string Email { get; set; }
	}
}