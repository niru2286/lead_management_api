using Microsoft.EntityFrameworkCore;
using pms_api.Abstract;
using pms_api.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pms_api.Repository
{
    public class CallData : ICall
    {
        private readonly pms_dbContext dbContext;

        public CallData(pms_dbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Task<int> Create(TblCall call)
        {
            dbContext.TblCalls.Add(call);
            return dbContext.SaveChangesAsync();
        }

        public Task<List<TblCall>> SelectAll(int accountId, int leadId, int status)
        {
            var data = dbContext.TblCalls.Where(x => x.AccountId==accountId && x.LeadId==leadId && x.Status == status).ToListAsync();
            return data;
        }

        public Task<TblCall> SelectById(int accountId, int callId)
        {
            var data = dbContext.TblCalls.Where(x => x.Status == 1 && x.CallId == callId
            && x.AccountId==accountId).FirstOrDefaultAsync();
            return data;
        }

        public Task<int> Update(TblCall call)
        {
            dbContext.Attach(call);
            return dbContext.SaveChangesAsync();
        }
    }
}
