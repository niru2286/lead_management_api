using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using pms_api.Model;
namespace pms_api.Abstract
{
    public interface ILead
    {
        Task<int> Create(TblLead lead);
        Task<int> Update(TblLead lead);
        Task<TblLead> SelectById(int accountId, int leadId);
        Task<List<TblLead>> SelectAll(int accountId, int status);
    }
}
