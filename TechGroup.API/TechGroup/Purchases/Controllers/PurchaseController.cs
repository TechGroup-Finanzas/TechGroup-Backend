using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using TechGroup.API.TechGroup.Purchases.Request;
using TechGroup.API.TechGroup.Purchases.Response;
using TechGroup.Infrastructure.TechGroup.Purchases.Interfaces;
using TechGroup.Infrastructure.TechGroup.Purchases.Models;

namespace TechGroup.API.TechGroup.Purchases.Controllers
{
    [EnableCors("AllowOrigin")]
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseController : ControllerBase
    {
        private readonly IPurchaseInfrastructure _purchaseInfrastructure;
        private readonly IMapper _mapper;

        public PurchaseController(IPurchaseInfrastructure purchaseInfrastructure, IMapper mapper)
        {
            _purchaseInfrastructure = purchaseInfrastructure;
            _mapper = mapper;
        }

        //GET : api/Purchase
        [HttpGet]
        public async Task<List<PurchaseResponse>> GetAllAsync()
        {
            var purchases = await _purchaseInfrastructure.GetAllAsync();
            var purchasesResponse = _mapper.Map<List<Purchase>, List<PurchaseResponse>>(purchases);
            return purchasesResponse;
        }

        [HttpGet("{id}")]
        public async Task<PurchaseResponse> GetByIdAsync(int id)
        {
            var purchase = await _purchaseInfrastructure.GetByIdAsync(id);
            var purchaseResponse = _mapper.Map<Purchase, PurchaseResponse>(purchase);
            return purchaseResponse;
        }

        //POST : api/Purchase
        [HttpPost]
        public async Task CreateAsync([FromBody] PurchaseRequest purchase)
        {
            if (ModelState.IsValid)
            {
                var purchaseToMapped = _mapper.Map<PurchaseRequest, Purchase>(purchase);
                await _purchaseInfrastructure.CreateAsync(purchaseToMapped);
            }
            else
            {
                StatusCode(400);
            }
        }

        //PUT : api/Purchase/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] PurchaseRequest purchase)
        {
            if (ModelState.IsValid)
            {
                var purchaseToMapped = _mapper.Map<PurchaseRequest, Purchase>(purchase);
                var purchaseUpdated = await _purchaseInfrastructure.UpdateAsync(id, purchaseToMapped);
                if (purchaseUpdated)
                {
                    return Ok();
                }
                return BadRequest();
            }
            else
            {
                return StatusCode(400);
            }
        }

        //DELETE : api/Purchase/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var purchaseDeleted = await _purchaseInfrastructure.DeleteAsync(id);
            if (purchaseDeleted)
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}
