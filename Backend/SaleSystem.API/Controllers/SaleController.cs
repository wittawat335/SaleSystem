﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SaleSystem.Core.DTO;
using SaleSystem.Core.Services.Contract;
using SaleSystem.Infrastructure.Utility;

namespace SaleSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaleController : ControllerBase
    {
        private readonly ISaleService _saleService;

        public SaleController(ISaleService saleService)
        {
            _saleService = saleService;
        }

        [HttpGet]
        [Route("Record")]
        public async Task<IActionResult> Search(string search, string? saleNumber, string? startDate, string? endDate)
        {
            var response = new Response<List<SaleDTO>>();
            saleNumber = saleNumber is null ? "" : saleNumber;
            startDate = startDate is null ? "" : startDate;
            endDate = endDate is null ? "" : endDate;

            try
            {
                response.value = await _saleService.Search(search, saleNumber, startDate, endDate);
                response.status = Constants.Status.True;
            }
            catch (Exception ex)
            {
                response.status = Constants.Status.False;
                response.message = ex.Message;
            }
            return Ok(response);
        }

        [HttpGet]
        [Route("Report")]
        public async Task<IActionResult> Report(string startDate, string endDate)
        {
            var response = new Response<List<ReportDTO>>();
            startDate = startDate is null ? "" : startDate;
            endDate = endDate is null ? "" : endDate;

            try
            {
                response.value = await _saleService.Report(startDate, endDate);
                response.status = Constants.Status.True;
            }
            catch (Exception ex)
            {
                response.status = Constants.Status.False;
                response.message = ex.Message;
            }
            return Ok(response);
        }


        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] SaleDTO model)
        {
            var response = new Response<SaleDTO>();
            try
            {
                response.value = await _saleService.Register(model);
                response.status = Constants.Status.True;
            }
            catch (Exception ex)
            {
                response.status = Constants.Status.False;
                response.message = ex.Message;
            }
            return Ok(response);
        }
    }
}
