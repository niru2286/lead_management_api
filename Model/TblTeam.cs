using System;
using System.Collections.Generic;

namespace pms_api.Model
{
    public partial class TblTeam
    {
        public TblTeam()
        {
            TblMembers = new HashSet<TblMember>();
        }

        public int TeamId { get; set; }
        public string Name { get; set; }
        public int Status { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public int AccountId { get; set; }

        public virtual TblAccount Account { get; set; }
        public virtual ICollection<TblMember> TblMembers { get; set; }
    }
}
