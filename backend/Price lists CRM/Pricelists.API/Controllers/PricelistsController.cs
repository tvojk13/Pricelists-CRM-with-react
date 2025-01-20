using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pricelists.API.Contracts;
using Pricelists.Application.Services;
using Pricelists.Core.Models;

namespace Pricelists.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PricelistsController : ControllerBase
    {
        private readonly IPricelistsService _pricelistsService;

        public PricelistsController(IPricelistsService pricelistsService)
        {
            _pricelistsService = pricelistsService;
        }

        [HttpGet]
        public async Task<ActionResult<List<PricelistsResponse>>> GetPricelists()
        {
            var pricelists = await _pricelistsService.GetAllPriceLists();

            var response = pricelists.Select(p => new PricelistsResponse(p.Id, p.Title, p.Text, p.Number, p.Date));

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<int?>> CreatePricelist([FromBody] PricelistsRequest request)
        {
            PricelistModel pricelist = PricelistModel.Create(null, request.Title, request.Text, request.Number, request.Date);

            var pricelistId = await _pricelistsService.CreatePricelist(pricelist);

            return Ok(pricelistId);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<int?>> UpdatePricelists(int? id, [FromBody] PricelistsRequest request)
        {
            var pricelistId = await _pricelistsService.UpdatePricelist(id, request.Title, request.Text, request.Number, request.Date);

            return Ok(pricelistId);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<int?>> DeletePricelists(int? id)
        {
            return Ok(await _pricelistsService.DeletePricelist(id));
        }
    }
}
