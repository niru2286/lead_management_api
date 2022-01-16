using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using pms_api.Model;
namespace pms_api.Abstract
{
    public interface ICall
    {
        Task<int> Create(TblCall call);
        Task<int> Update(TblCall call);
        Task<TblCall> SelectById(int accountId, int callId);
        Task<List<TblCall>> SelectAll(int accountId, int leadId,int status);        
    }
}
