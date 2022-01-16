using System;
using System.Collections.Generic;

namespace pms_api.Model
{
    public partial class TblMember
    {
        public TblMember()
        {
            TblCalls = new HashSet<TblCall>();
            TblContacts = new HashSet<TblContact>();
            TblLeadAssignedToNavigations = new HashSet<TblLead>();
            TblLeadCreatedByNavigations = new HashSet<TblLead>();
            TblNotes = new HashSet<TblNote>();
        }

        public int MemberId { get; set; }
        public string Name { get; set; }
        public string EmailId { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public int TeamId { get; set; }
        public int AccountId { get; set; }
        public int Status { get; set; }

        public virtual TblAccount Account { get; set; }
        public virtual TblTeam Team { get; set; }
        public virtual ICollection<TblCall> TblCalls { get; set; }
        public virtual ICollection<TblContact> TblContacts { get; set; }
        public virtual ICollection<TblLead> TblLeadAssignedToNavigations { get; set; }
        public virtual ICollection<TblLead> TblLeadCreatedByNavigations { get; set; }
        public virtual ICollection<TblNote> TblNotes { get; set; }
    }
}
