using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using pms_api.Model;
namespace pms_api.Abstract
{
    public interface IMembers
    {
        Task<int> Create(TblMember member);
        Task<int> Update(TblMember member);
        Task<TblMember> SelectById(int accountId, int memberId);
        Task<List<TblMember>> SelectAll(int accountId);
        Task<List<TblMember>> SelectAllByStatus(int accountId, int status);
    }
}
