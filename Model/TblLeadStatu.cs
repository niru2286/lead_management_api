using System;
using System.Collections.Generic;

namespace pms_api.Model
{
    public partial class TblLeadStatu
    {
        public TblLeadStatu()
        {
            TblLeads = new HashSet<TblLead>();
        }

        public int StatusId { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public int AccountId { get; set; }

        public virtual TblAccount Account { get; set; }
        public virtual ICollection<TblLead> TblLeads { get; set; }
    }
}
