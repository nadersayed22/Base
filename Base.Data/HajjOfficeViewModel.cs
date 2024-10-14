using Base.Model1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Data1
{
    public class HajjOfficeViewModel
    {
        public IEnumerable<HajjOffice> HajjOffices { get; set; }
        public OfficeReq OfficeReq { get; set; }
    }
}
