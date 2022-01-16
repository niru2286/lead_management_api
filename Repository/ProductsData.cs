using Microsoft.EntityFrameworkCore;
using pms_api.Abstract;
using pms_api.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pms_api.Repository
{
    public class ProductsData : IProducts
    {
        private readonly pms_dbContext dbContext;

        public ProductsData(pms_dbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Task<int> Create(TblProduct product)
        {
            dbContext.TblProducts.Add(product);
            return dbContext.SaveChangesAsync();
        }

        public Task<List<TblProduct>> SelectAll(int accountId)
        {
            var data = dbContext.TblProducts.Where(x => x.AccountId==accountId).ToListAsync();
            return data;
        }

        public Task<List<TblProduct>> SelectAllByStatus(int accountId, int status)
        {
            var data = dbContext.TblProducts.Where(x => x.AccountId == accountId && x.Status == status).ToListAsync();
            return data;
        }

        public Task<TblProduct> SelectById(int accountId, int productId)
        {
            var data = dbContext.TblProducts.Where(x => x.Status == 1 && x.ProductId == productId
            && x.AccountId==accountId).FirstOrDefaultAsync();
            return data;
        }

        public Task<int> Update(TblProduct product)
        {
            //dbContext.Attach(product);
            dbContext.Entry(product).Property(x => x.CreatedOn).IsModified = false;
            dbContext.Update(product);
            return dbContext.SaveChangesAsync();
        }
    }
}
