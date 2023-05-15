using AutoMapper;
using SaleSystem.Core.Domain;
using SaleSystem.Core.Domain.RepositoryContracts;
using SaleSystem.Core.DTO;
using SaleSystem.Core.Services.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaleSystem.Core.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IGenericRepository<Category> _repository;
        private readonly IMapper _mapper;

        public CategoryService(IGenericRepository<Category> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<CategoryDTO>> GetList()
        {
            try
            {
                var list = await _repository.GetListAsync();
                return _mapper.Map<List<CategoryDTO>>(list.ToList());
            }
            catch {
                throw;
            }
        }
    }
}
