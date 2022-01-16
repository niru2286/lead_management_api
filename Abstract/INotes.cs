using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using pms_api.Model;
namespace pms_api.Abstract
{
    public interface INotes
    {
        Task<int> Create(TblNote note);
        Task<int> Update(TblNote note);
        Task<TblNote> SelectById(int accountId, int callId);
        Task<List<TblNote>> SelectAll(int accountId, int leadId,int status);        
    }
}
