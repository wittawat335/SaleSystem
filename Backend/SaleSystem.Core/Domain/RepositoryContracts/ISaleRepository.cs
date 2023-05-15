using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaleSystem.Core.Domain.RepositoryContracts
{
    public interface ISaleRepository : IGenericRepository<Sale>
    {
        Task<Sale> CreateAsync(Sale entity);
    }
}
