using Microsoft.EntityFrameworkCore;
using pms_api.Abstract;
using pms_api.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pms_api.Repository
{
    public class LeadData : ILead
    {
        private readonly pms_dbContext dbContext;

        public LeadData(pms_dbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Task<int> Create(TblLead lead)
        {
            dbContext.TblLeads.Add(lead);
            return dbContext.SaveChangesAsync();
        }

        public Task<List<TblLead>> SelectAll(int accountId, int status)
        {
            var data = dbContext.TblLeads.Where(x => x.AccountId==accountId && x.Status == status).ToListAsync();
            return data;
        }

        public Task<TblLead> SelectById(int accountId, int leadId)
        {
            var data = dbContext.TblLeads.Where(x => x.Status == 1 && x.LeadId == leadId
            && x.AccountId==accountId).FirstOrDefaultAsync();
            return data;
        }

        public Task<int> Update(TblLead lead)
        {
            dbContext.Attach(lead);
            return dbContext.SaveChangesAsync();
        }
    }
}
