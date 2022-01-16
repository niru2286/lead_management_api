using Microsoft.EntityFrameworkCore;
using pms_api.Abstract;
using pms_api.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pms_api.Repository
{
    public class MembersData : IMembers
    {
        private readonly pms_dbContext dbContext;

        public MembersData(pms_dbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Task<int> Create(TblMember member)
        {
            dbContext.TblMembers.Add(member);
            return dbContext.SaveChangesAsync();
        }

        public Task<List<TblMember>> SelectAll(int accountId)
        {
            var data = dbContext.TblMembers.Where(x => x.AccountId==accountId).ToListAsync();
            return data;
        }

        public Task<List<TblMember>> SelectAllByStatus(int accountId, int status)
        {
            var data = dbContext.TblMembers.Where(x => x.AccountId == accountId && x.Status==status).ToListAsync();
            return data;
        }

        public Task<TblMember> SelectById(int accountId, int memberId)
        {
            var data = dbContext.TblMembers.Where(x => x.MemberId == memberId
            && x.AccountId==accountId).FirstOrDefaultAsync();
            return data;
        }

        public Task<int> Update(TblMember member)
        {            
            dbContext.Entry(member).Property(x => x.CreatedOn).IsModified = false;
            dbContext.Update(member);
            return dbContext.SaveChangesAsync();
        }
    }
}
