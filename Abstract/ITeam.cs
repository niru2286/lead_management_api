using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using pms_api.Model;
namespace pms_api.Abstract
{
    public interface ITeam
    {
        Task<int> Create(TblTeam team);
        Task<int> Update(TblTeam team);
        Task<TblTeam> SelectById(int accountId, int sourceId);
        Task<List<TblTeam>> SelectAll(int accountId);
        Task<List<TblTeam>> SelectAllByStatus(int accountId, int status);
    }
}
