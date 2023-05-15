using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SaleSystem.Core.Domain.RepositoryContracts;
using SaleSystem.Core.Domain;
using SaleSystem.Core.DTO;
using SaleSystem.Core.Services.Contract;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaleSystem.Core.Services
{
    public class SaleService : ISaleService
    {
        private readonly ISaleRepository _saleRepository;
        private readonly IGenericRepository<SaleDetail> _saleDetailRepository;
        private readonly IMapper _mapper;

        public SaleService(ISaleRepository saleRepository, IGenericRepository<SaleDetail> saleDetailRepository, IMapper mapper)
        {
            _saleRepository = saleRepository;
            _saleDetailRepository = saleDetailRepository;
            _mapper = mapper;
        }

        public async Task<List<SaleDTO>> Search(string search, string saleNumber, string startDate, string endDate)
        {
            IQueryable<Sale> query = await _saleRepository.GetList();
            var list = new List<Sale>();
            try
            {
                if (search == "Date")
                {
                    DateTime start_date = DateTime.ParseExact(startDate, "dd/MM/yyyy", new CultureInfo("en-US"));
                    DateTime end_date = DateTime.ParseExact(endDate, "dd/MM/yyyy", new CultureInfo("en-US"));

                    list = await query.Where(x =>
                    x.CreateDate.Value.Date >= start_date.Date &&
                    x.CreateDate.Value.Date <= end_date.Date
                    ).Include(y => y.SaleDetails)
                    .ThenInclude(z => z.Product).ToListAsync();
                }
                else
                {
                    list = await query.Where(x => x.DocumentNumber == saleNumber).Include(y => y.SaleDetails)
                    .ThenInclude(z => z.Product).ToListAsync();
                }
            }
            catch
            {
                throw;
            }

            return _mapper.Map<List<SaleDTO>>(list);
        }

        public async Task<SaleDTO> Register(SaleDTO model)
        {
            try
            {
                var sale = await _saleRepository.CreateAsync(_mapper.Map<Sale>(model));
                if (sale == null)
                    throw new TaskCanceledException("");

                return _mapper.Map<SaleDTO>(sale);
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<ReportDTO>> Report(string startDate, string endDate)
        {
            IQueryable<SaleDetail> query = await _saleDetailRepository.GetList();
            var list = new List<SaleDetail>();
            try
            {
                DateTime start_date = DateTime.ParseExact(startDate, "dd/MM/yyyy", new CultureInfo("en-US"));
                DateTime end_date = DateTime.ParseExact(endDate, "dd/MM/yyyy", new CultureInfo("en-US"));

                list = await query
                    .Include(x => x.Product)
                    .Include(y => y.Sale)
                    .Where(z =>
                        z.Sale.CreateDate.Value.Date >= start_date.Date &&
                        z.Sale.CreateDate.Value.Date <= end_date.Date
                    ).ToListAsync();
            }
            catch
            {
                throw;
            }
            return _mapper.Map<List<ReportDTO>>(list);
        }

       
    }
}
