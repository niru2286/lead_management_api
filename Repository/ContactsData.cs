using Microsoft.EntityFrameworkCore;
using pms_api.Abstract;
using pms_api.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pms_api.Repository
{
    public class ContactData : IContacts
    {
        private readonly pms_dbContext dbContext;

        public ContactData(pms_dbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Task<int> Create(TblContact contact)
        {
            dbContext.TblContacts.Add(contact);
            return dbContext.SaveChangesAsync();
        }

        public Task<List<TblContact>> SelectAll(int accountId, int leadId, int status)
        {
            var data = dbContext.TblContacts.Where(x => x.AccountId==accountId && x.LeadId==leadId && x.Status == status).ToListAsync();
            return data;
        }

        public Task<TblContact> SelectById(int accountId, int contactId)
        {
            var data = dbContext.TblContacts.Where(x => x.Status == 1 && x.ContactId == contactId
            && x.AccountId==accountId).FirstOrDefaultAsync();
            return data;
        }

        public Task<int> Update(TblContact contact)
        {
            dbContext.Attach(contact);
            return dbContext.SaveChangesAsync();
        }
    }
}
