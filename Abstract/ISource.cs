using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using pms_api.Model;
namespace pms_api.Abstract
{
    public interface ISource
    {
        Task<int> Create(TblSource source);
        Task<int> Update(TblSource source);
        Task<TblSource> SelectById(int accountId, int sourceId);
        Task<List<TblSource>> SelectAll(int accountId);
        Task<List<TblSource>> SelectAllByStatus(int accountId, int status);
    }
}
