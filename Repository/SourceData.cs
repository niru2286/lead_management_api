using Microsoft.EntityFrameworkCore;
using pms_api.Abstract;
using pms_api.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pms_api.Repository
{
    public class SourceData : ISource
    {
        private readonly pms_dbContext dbContext;

        public SourceData(pms_dbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Task<int> Create(TblSource source)
        {
            dbContext.TblSources.Add(source);
            return dbContext.SaveChangesAsync();
        }

        public Task<List<TblSource>> SelectAll(int accountId)
        {
            var data = dbContext.TblSources.Where(x => x.AccountId==accountId).ToListAsync();
            return data;
        }

        public Task<List<TblSource>> SelectAllByStatus(int accountId, int status)
        {
            var data = dbContext.TblSources.Where(x => x.AccountId == accountId && x.Status == status).ToListAsync();
            return data;
        }

        public Task<TblSource> SelectById(int accountId, int sourceId)
        {
            var data = dbContext.TblSources.Where(x => x.SourceId == sourceId 
            && x.AccountId==accountId).FirstOrDefaultAsync();
            return data;
        }

        public Task<int> Update(TblSource source)
        {            
            dbContext.Entry(source).Property(x => x.CreatedOn).IsModified = false;
            dbContext.Update(source);
            return dbContext.SaveChangesAsync();
        }
    }
}
