using System;
using System.Collections.Generic;

namespace pms_api.Model
{
    public partial class TblContact
    {
        public int ContactId { get; set; }
        public string Name { get; set; }
        public string Designation { get; set; }
        public string EmailId { get; set; }
        public string MobileNo { get; set; }
        public string Remarks { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? CreatedBy { get; set; }
        public int? Status { get; set; }
        public int? LeadId { get; set; }
        public int? AccountId { get; set; }

        public virtual TblAccount Account { get; set; }
        public virtual TblMember CreatedByNavigation { get; set; }
        public virtual TblLead Lead { get; set; }
    }
}
