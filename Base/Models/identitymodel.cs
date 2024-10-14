using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace Base.Models
{
	public class identitymodel
	{
		// You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
		public class ApplicationUser : IdentityUser
		{
			public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
			{
				// Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
				var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
				// Add custom user claims here
				//userIdentity.AddClaim(new Claim(ClaimTypes.Email, "ahmed_nagy1991@hotmail.com"));
				return userIdentity;
			}
		}

		public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
		{
			public ApplicationDbContext()
				: base("BaseEntities", throwIfV1Schema: false)
			{
			}

			public static ApplicationDbContext Create()
			{
				return new ApplicationDbContext();
			}
		}
	}
}