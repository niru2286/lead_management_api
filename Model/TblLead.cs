using System;
using System.Collections.Generic;

namespace pms_api.Model
{
    public partial class TblLead
    {
        public TblLead()
        {
            TblCalls = new HashSet<TblCall>();
            TblContacts = new HashSet<TblContact>();
            TblNotes = new HashSet<TblNote>();
        }

        public int LeadId { get; set; }
        public string Title { get; set; }
        public string Name { get; set; }
        public string EmailId { get; set; }
        public string Mobile { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Pincode { get; set; }
        public int? InterestedIn { get; set; }
        public int? SourceId { get; set; }
        public int? AssignedTo { get; set; }
        public string Comments { get; set; }
        public int? Status { get; set; }
        public int AccountId { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? CreatedBy { get; set; }

        public virtual TblAccount Account { get; set; }
        public virtual TblMember AssignedToNavigation { get; set; }
        public virtual TblMember CreatedByNavigation { get; set; }
        public virtual TblProduct InterestedInNavigation { get; set; }
        public virtual TblSource Source { get; set; }
        public virtual TblLeadStatu StatusNavigation { get; set; }
        public virtual ICollection<TblCall> TblCalls { get; set; }
        public virtual ICollection<TblContact> TblContacts { get; set; }
        public virtual ICollection<TblNote> TblNotes { get; set; }
    }
}
