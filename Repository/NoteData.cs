using Microsoft.EntityFrameworkCore;
using pms_api.Abstract;
using pms_api.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pms_api.Repository
{
    public class NoteData : INotes
    {
        private readonly pms_dbContext dbContext;

        public NoteData(pms_dbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Task<int> Create(TblNote note)
        {
            dbContext.TblNotes.Add(note);
            return dbContext.SaveChangesAsync();
        }

        public Task<List<TblNote>> SelectAll(int accountId, int leadId, int status)
        {
            var data = dbContext.TblNotes.Where(x => x.AccountId==accountId && x.LeadId==leadId && x.Status == status).ToListAsync();
            return data;
        }

        public Task<TblNote> SelectById(int accountId, int noteId)
        {
            var data = dbContext.TblNotes.Where(x => x.Status == 1 && x.NoteId == noteId
            && x.AccountId==accountId).FirstOrDefaultAsync();
            return data;
        }

        public Task<int> Update(TblNote note)
        {
            dbContext.Attach(note);
            return dbContext.SaveChangesAsync();
        }
    }
}
