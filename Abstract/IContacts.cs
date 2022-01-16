using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using pms_api.Model;
namespace pms_api.Abstract
{
    public interface IContacts
    {
        Task<int> Create(TblContact contact);
        Task<int> Update(TblContact contact);
        Task<TblContact> SelectById(int accountId, int contactId);
        Task<List<TblContact>> SelectAll(int accountId, int leadId,int status);        
    }
}
