using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SaleSystem.Core.Domain;
using SaleSystem.Core.Domain.RepositoryContracts;
using SaleSystem.Core.DTO;
using SaleSystem.Core.Services.Contract;

namespace SaleSystem.Core.Services
{
    public class ProductService : IProductService
    {
        private readonly IGenericRepository<Product> _repository;
        private readonly IMapper _mapper;

        public ProductService(IGenericRepository<Product> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<ProductDTO>> GetList()
        {
            try
            {

                var query = await _repository.GetListAsync();
                var list = query.Include(x => x.Category).ToList();

                return _mapper.Map<List<ProductDTO>>(list);
            }
            catch
            {
                throw;
            }
        }

        public async Task<ProductDTO> Insert(ProductDTO model)
        {
            try
            {
                var productCreate = await _repository.InsertAsync(_mapper.Map<Product>(model));
                if (productCreate.ProductId == 0)
                {
                    throw new TaskCanceledException("Cannot Map Data");
                }

                return _mapper.Map<ProductDTO>(productCreate);
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Update(ProductDTO model)
        {
            try
            {
                var mapper = _mapper.Map<Product>(model);
                var dataUpdate = await _repository.GetAsync(x => x.ProductId == mapper.ProductId);
                if (dataUpdate == null)
                    throw new TaskCanceledException("No Data");

                dataUpdate.Name = mapper.Name;
                dataUpdate.CategoryId = mapper.CategoryId;
                dataUpdate.Stock = mapper.Stock;
                dataUpdate.Price = mapper.Price;
                dataUpdate.IsActive = mapper.IsActive;

                bool updated = await _repository.UpdateAsync(dataUpdate);
                if (!updated)
                    throw new TaskCanceledException("Cannot Update Data");

                return updated;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                var query = await _repository.GetAsync(x => x.ProductId == id);
                if (query == null)
                    throw new TaskCanceledException("No Data");

                bool deleted = await _repository.DeleteAsync(query);
                if (deleted == null)
                    throw new TaskCanceledException("No Data");

                return deleted;
            }
            catch
            {
                throw;
            }
        }
    }
}
