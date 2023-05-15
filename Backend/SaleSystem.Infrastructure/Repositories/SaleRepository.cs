using SaleSystem.Core.Domain;
using SaleSystem.Core.Domain.RepositoryContracts;
using SaleSystem.Infrastructure.DBContext;

namespace SaleSystem.Infrastructure.Repositories
{
    public class SaleRepository : GenericRepository<Sale>, ISaleRepository
    {
        private readonly SaleSystemDbContext _dbContext;

        public SaleRepository(SaleSystemDbContext dbContext) : base(dbContext) 
        {
            _dbContext = dbContext;
        }

        public async Task<Sale> CreateAsync(Sale entity)
        {
            Sale sale = new Sale();
            using (var transaction = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    foreach (var item in entity.SaleDetails)
                    {
                        var product = _dbContext.Products.Where(x => x.ProductId == item.ProductId).First();

                        product.Stock = product.Stock - item.Quantity;
                        _dbContext.Products.Update(product);
                    }
                    await _dbContext.SaveChangesAsync();

                    var docNumber = _dbContext.DocumentNumbers.First();

                    docNumber.LastNumber = docNumber.LastNumber + 1;
                    docNumber.CreateDate = DateTime.Now;

                    _dbContext.DocumentNumbers.Update(docNumber);
                    await _dbContext.SaveChangesAsync();

                    int digi = 4;
                    string test = string.Concat(Enumerable.Repeat("0", digi));
                    string test2 = test + docNumber.LastNumber.ToString();

                    //00001
                    test2 = test2.Substring(test2.Length - digi, digi);
                    entity.DocumentNumber = test2;
                    await _dbContext.Sales.AddAsync(entity);
                    await _dbContext.SaveChangesAsync();

                    sale = entity;
                    transaction.Commit();

                }
                catch
                {
                    transaction.Rollback();
                    throw;

                }

                return sale;
            }
        }
    
    }
}
