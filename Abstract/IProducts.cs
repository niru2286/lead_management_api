using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using pms_api.Model;
namespace pms_api.Abstract
{
    public interface IProducts
    {
        Task<int> Create(TblProduct product);
        Task<int> Update(TblProduct product);
        Task<TblProduct> SelectById(int accountId, int productId);
        Task<List<TblProduct>> SelectAll(int accountId);
        Task<List<TblProduct>> SelectAllByStatus(int accountId, int status);
    }
}
