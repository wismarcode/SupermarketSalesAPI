using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SupermarketSalesAPI.DTOs.SaleDTOs;
using SupermarketSalesAPI.Models;
using SupermarketSalesAPI.Services.SaleServices;

namespace SupermarketSalesAPI.Controllers
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
        public async Task<ActionResult<IEnumerable<Sale>>> GetAllSales()
        {
            var sales = await _saleService.GetAllSalesAsync();
            return Ok(sales);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Sale>> GetSaleById(int id)
        {
            var sale = await _saleService.GetSaleByIdAsync(id);
            if (sale == null)
            {
                return NotFound();
            }
            return Ok(sale);
        }

        [HttpPost]
        public async Task<ActionResult<Sale>> CreateSale(CreateSaleDto createSaleDto)
        {
            try
            {
                var createdSale = await _saleService.CreateSaleAsync(createSaleDto);
                return CreatedAtAction(nameof(GetSaleById), new { id = createdSale.SaleId }, createdSale);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }

        }

        [HttpPut("{id}/cancellation")]
        public async Task<ActionResult> CancelSaleAsync(int id)
        {

            try
            {
                await _saleService.CancelSaleAsync(id);
                return NoContent();

            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }

        }

        [HttpPut("{id}/payment")]
        public async Task<ActionResult> PaySaleAsync(int id)
        {
            try
            {
                await _saleService.PaySaleAsync(id);
                return NoContent();

            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPut("{id}/detail/{detailId}")]
        public async Task<ActionResult> UpdateSaleDetailAsync(int id, int detailId, UpdateSaleDetailDto updateSaleDetailDto)
        {
            try
            {
                await _saleService.UpdateSaleDetailAsync(id, detailId, updateSaleDetailDto);
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteSaleAsync(int id)
        {
            try
            {
                await _saleService.DeleteSaleAsync(id);
                return NoContent();

            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

    }
}
