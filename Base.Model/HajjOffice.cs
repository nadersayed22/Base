

using Base.Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Base.Model1
{
	public class HajjOffice
	{
		[Key]
		public int ID { get; set; }
        public string OfficeName { get; set; }
        public int OfficeRepresentativeID { get; set; }
        public string OfficePhone { get; set; }

		[ForeignKey("OfficeRepresentativeID")]
		public UserModel Representative { get; set; }
    }
}
