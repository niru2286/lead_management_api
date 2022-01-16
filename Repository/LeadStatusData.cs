using Microsoft.EntityFrameworkCore;
using pms_api.Abstract;
using pms_api.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pms_api.Repository
{
    public class LeadStatusData : ILeadStatus
    {
        private readonly pms_dbContext dbContext;

        public LeadStatusData(pms_dbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Task<int> Create(TblLeadStatu status)
        {
            dbContext.TblLeadStatus.Add(status);
            return dbContext.SaveChangesAsync();
        }

        public Task<List<TblLeadStatu>> SelectAll(int accountId)
        {
            var data = dbContext.TblLeadStatus.Where(x => x.AccountId==accountId).ToListAsync();
            return data;
        }

        public Task<TblLeadStatu> SelectById(int accountId, int statusId)
        {
            var data = dbContext.TblLeadStatus.Where(x => x.StatusId == statusId
            && x.AccountId==accountId).FirstOrDefaultAsync();
            return data;
        }

        public Task<int> Update(TblLeadStatu status)
        {
            dbContext.Attach(status);
            return dbContext.SaveChangesAsync();
        }
    }
}
