using System;
using System.Collections.Generic;

namespace pms_api.Model
{
    public partial class TblAccount
    {
        public TblAccount()
        {
            TblCalls = new HashSet<TblCall>();
            TblContacts = new HashSet<TblContact>();
            TblLeadStatus = new HashSet<TblLeadStatu>();
            TblLeads = new HashSet<TblLead>();
            TblMembers = new HashSet<TblMember>();
            TblNotes = new HashSet<TblNote>();
            TblProducts = new HashSet<TblProduct>();
            TblSources = new HashSet<TblSource>();
            TblTeams = new HashSet<TblTeam>();
        }

        public int AccountId { get; set; }
        public string Name { get; set; }
        public int Status { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }

        public virtual ICollection<TblCall> TblCalls { get; set; }
        public virtual ICollection<TblContact> TblContacts { get; set; }
        public virtual ICollection<TblLeadStatu> TblLeadStatus { get; set; }
        public virtual ICollection<TblLead> TblLeads { get; set; }
        public virtual ICollection<TblMember> TblMembers { get; set; }
        public virtual ICollection<TblNote> TblNotes { get; set; }
        public virtual ICollection<TblProduct> TblProducts { get; set; }
        public virtual ICollection<TblSource> TblSources { get; set; }
        public virtual ICollection<TblTeam> TblTeams { get; set; }
    }
}
