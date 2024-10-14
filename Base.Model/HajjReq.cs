
using System.ComponentModel.DataAnnotations;

namespace Base.Model1
{
	public class HajjReq
	{
		[Key]
		public int ID { get; set; }
        public string Name { get; set; }
    }
}
