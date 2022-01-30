using Microsoft.EntityFrameworkCore;
using pms_api.Abstract;
using pms_api.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pms_api.Repository
{
    public class TeamData : ITeam
    {
        private readonly pms_dbContext dbContext;

        public TeamData(pms_dbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Task<int> Create(TblTeam team)
        {
            dbContext.TblTeams.Add(team);
            return dbContext.SaveChangesAsync();
        }

        public Task<List<TblTeam>> SelectAll(int accountId)
        {
            var data = dbContext.TblTeams.Where(x => x.AccountId==accountId).ToListAsync();
            return data;
        }

        public Task<List<TblTeam>> SelectAllByStatus(int accountId, int status)
        {
            var data = dbContext.TblTeams.Where(x => x.AccountId == accountId && x.Status == status).ToListAsync();
            return data;
        }

        public Task<TblTeam> SelectById(int accountId, int teamId)
        {
            var data = dbContext.TblTeams.Where(x => x.TeamId == teamId
            && x.AccountId==accountId).FirstOrDefaultAsync();
            return data;
        }

        public Task<int> Update(TblTeam team)
        {            
            dbContext.Entry(team).Property(x => x.CreatedOn).IsModified = false;
            dbContext.Update(team);
            return dbContext.SaveChangesAsync();
        }
    }
}
