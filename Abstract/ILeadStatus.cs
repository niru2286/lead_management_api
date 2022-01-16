using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using pms_api.Model;
namespace pms_api.Abstract
{
    public interface ILeadStatus
    {
        Task<int> Create(TblLeadStatu leadStatus);
        Task<int> Update(TblLeadStatu leadStatus);
        Task<TblLeadStatu> SelectById(int accountId, int statusID);
        Task<List<TblLeadStatu>> SelectAll(int accountId);        
    }
}
