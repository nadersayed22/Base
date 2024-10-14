using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StingRay.Utility.CommonModels
{
    public class SharedUserDataModel
    {
        public long UserID { get; set; }
        public long usertype { get; set; }
        public long CreatedBy { get; set; }
        public long FK_AccountID { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string DisplayName { get; set; }
        public string CompanyDomain { get; set; }
        [Required]
        public string DisplayNameAr { get; set; }
        [Required]
        [RegularExpression(@"(^(([0]{2})|(\+))[1-9][0-9]*\.?[0-9]+$)", ErrorMessage = "Mobile Is not an international number, must start with + or with 00")]
        public string Mobile { get; set; }
        public string Phone { get; set; }
        public string ContactEmail { get; set; }
        public string ContactName { get; set; }
        public string Country { get; set; }
        public string CountryShortCode { get; set; }
        public string City { get; set; }
        public string Website { get; set; }
        public string Logo { get; set; }
        [Required]
        public string Password { get; set; }
        [Compare(nameof(Password), ErrorMessage = "Password and Confirm password must be the same")]
        [Required]
        public string ConfirmPassword { get; set; }
        public string PasswordHashed { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsActive { get; set; }
        public bool IsMainAdmin { get; set; }
        public bool? IsParent { get; set; }
        public long? ParentAccID { get; set; }
    }
}
