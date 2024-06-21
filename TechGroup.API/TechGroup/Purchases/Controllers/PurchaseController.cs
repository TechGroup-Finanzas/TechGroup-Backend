using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using TechGroup.API.TechGroup.Purchases.Request;
using TechGroup.API.TechGroup.Purchases.Response;
using TechGroup.Domain.TechGroup.Purchases.Interfaces;
using TechGroup.Infrastructure.TechGroup.Purchases.Interfaces;
using TechGroup.Infrastructure.TechGroup.Purchases.Models;

namespace TechGroup.API.TechGroup.Purchases.Controllers
{
    [EnableCors("AllowOrigin")]
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseController : ControllerBase
    {
        private readonly IPurchaseDomain _purchaseDomain;
        private readonly IMapper _mapper;
        private readonly IPurchaseInfrastructure _purchaseInfrastructure;

        public PurchaseController(IPurchaseDomain purchaseDomain, IMapper mapper, IPurchaseInfrastructure purchaseInfrastructure)
        {
            _purchaseDomain = purchaseDomain;
            _mapper = mapper;
            _purchaseInfrastructure = purchaseInfrastructure;
        }

        //GET : api/Purchase
        [HttpGet]
        public async Task<List<PurchaseResponse>> GetAllAsync()
        {
            var purchases = await _purchaseInfrastructure.GetAllAsync();
            var purchasesResponse = _mapper.Map<List<Purchase>, List<PurchaseResponse>>(purchases);
            return purchasesResponse;
        }

        //GET : api/Purchase/5
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
                await _purchaseDomain.CreatePurchaseAsync(purchaseToMapped);
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
                await _purchaseDomain.UpdatePurchaseAsync(id, purchaseToMapped);
                return Ok();
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
            await _purchaseDomain.DeletePurchaseAsync(id);
            return Ok();
        }
        
        //GET : api/Purchase/GetByUserId/5
        [HttpGet("GetByUserId/{userId}")]
        public async Task<List<PurchaseResponse>> GetByUserIdAsync(int userId)
        {
            var purchases = await _purchaseInfrastructure.GetByUserIdAsync(userId);
            var purchasesResponse = _mapper.Map<List<Purchase>, List<PurchaseResponse>>(purchases);
            return purchasesResponse;
        }
        
        //GET : api/Purchase/GetByDateRange/2022-01-01/2022-12-31
        [HttpGet("GetByDateRange/{startDate}/{endDate}")]
        public async Task<List<PurchaseResponse>> GetByDateRangeAsync(DateOnly startDate, DateOnly endDate)
        {
            var purchases = await _purchaseInfrastructure.GetByDateRangeAsync(startDate, endDate);
            var purchasesResponse = _mapper.Map<List<Purchase>, List<PurchaseResponse>>(purchases);
            return purchasesResponse;
        }
         
    }
}