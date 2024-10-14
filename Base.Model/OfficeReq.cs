
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Base.Model1
{
	public class OfficeReq
	{
        [Key]
        public int ID { get; set; }
        public int officeID { get; set; }
        public int reqID { get; set; }
        public bool isBool { get; set; }
        public int Amount { get; set; }
        public int ActualAmount { get; set; }

        [ForeignKey("officeID")]
        public HajjOffice HajjOffice { get; set; }

		[ForeignKey("reqID")]
		public HajjReq HajjReq { get; set; }
    }
}
