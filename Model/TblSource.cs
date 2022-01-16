﻿using System;
using System.Collections.Generic;

namespace pms_api.Model
{
    public partial class TblSource
    {
        public TblSource()
        {
            TblLeads = new HashSet<TblLead>();
        }

        public int SourceId { get; set; }
        public string Name { get; set; }
        public int Status { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public int AccountId { get; set; }

        public virtual TblAccount Account { get; set; }
        public virtual ICollection<TblLead> TblLeads { get; set; }
    }
}
