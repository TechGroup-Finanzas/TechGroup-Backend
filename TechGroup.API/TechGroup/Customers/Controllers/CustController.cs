using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using TechGroup.API.TechGroup.Customers.Request;
using TechGroup.API.TechGroup.Customers.Response;
using TechGroup.Domain.TechGroup.Customers.Interfaces;
using TechGroup.Infrastructure.TechGroup.Customers.Interfaces;
using TechGroup.Infrastructure.TechGroup.Customers.Models;

namespace TechGroup.API.TechGroup.Customers.Controllers
{
    [EnableCors("AllowOrigin")]
    [Route("api/[controller]")]
    [ApiController]
    public class CustController : ControllerBase
    {
        private readonly ICustDomain _custDomain;
        private readonly IMapper _mapper;
        private readonly ICustInfrastructure _custInfrastructure;

        public CustController(ICustDomain custDomain, IMapper mapper, ICustInfrastructure custInfrastructure)
        {
            _custDomain = custDomain;
            _mapper = mapper;
            _custInfrastructure = custInfrastructure;
        }

        //GET : api/User
        [HttpGet]
        public async Task<List<CustResponse>> GetAllAsync()
        {
            var custs = await _custInfrastructure.GetAllAsync();
            var custsResponse = _mapper.Map<List<Customer>, List<CustResponse>>(custs);
            return custsResponse;
        }

        //GET : api/User/5
        [HttpGet("{id}")]
        public async Task<CustResponse> GetByIdAsync(int id)
        {
            var cust = await _custInfrastructure.GetByIdAsync(id);
            var custResponse = _mapper.Map<Customer, CustResponse>(cust);
            return custResponse;
        }

        //POST : api/User
        [HttpPost]
        public async Task CreateAsync([FromBody] CustRequest cust)
        {
            if (ModelState.IsValid)
            {
                var custToMapped = _mapper.Map<CustRequest, Customer>(cust);
                await _custDomain.SaveAsync(custToMapped);
            }
            else
            {
                StatusCode(400);
            }
        }

        //PUT : api/User/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] CustRequest cust)
        {
            var custToMapped = _mapper.Map<CustRequest, Customer>(cust);
            var custUpdated = await _custDomain.UpdateAsync(id, custToMapped);
            if (custUpdated)
            {
                return Ok();
            }
            return BadRequest();
        }

        //DELETE : api/User/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var custDeleted = await _custDomain.DeleteAsync(id);
            if (custDeleted)
            {
                return Ok();
            }
            return BadRequest();
        }

    }
}
