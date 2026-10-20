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
            var createdSale = await _saleService.CreateSaleAsync(createSaleDto);
            return CreatedAtAction(nameof(GetSaleById), new { id = createdSale.SaleId }, createdSale);
        }

        [HttpPut("{id}/cancellation")]
        public async Task<ActionResult> CancelSaleAsync(int id)
        {
            var sale = await _saleService.CancelSaleAsync(id);
            if (sale == false)
            {
                return NotFound();
            }

            await _saleService.CancelSaleAsync(id);

            return NoContent();

        }

        [HttpPut("{id}/payment")]
        public async Task<ActionResult> PaySaleAsync(int id)
        {
            var sale = await _saleService.PaySaleAsync(id);
            if (sale == false)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpPut("{id}/detail/{detailId}")]
        public async Task<ActionResult> UpdateSaleDetailAsync(int id, int detailId, UpdateSaleDetailDto updateSaleDetailDto)
        {
            var sale = await _saleService.UpdateSaleDetailAsync(id, detailId, updateSaleDetailDto);
            if (sale == false)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteSaleAsync(int id)
        {
            var sale = await _saleService.DeleteSaleAsync(id);
            if (sale == false)
            {
                return NotFound();
            }
            return NoContent();
        }

    }
}
