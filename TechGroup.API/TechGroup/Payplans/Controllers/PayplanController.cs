using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using TechGroup.API.TechGroup.Payplans.Request;
using TechGroup.API.TechGroup.Payplans.Response;
using TechGroup.Infrastructure.TechGroup.Payplans.Interfaces;
using TechGroup.Infrastructure.TechGroup.Payplans.Models;

namespace TechGroup.API.TechGroup.Payplans.Controllers
{
    [EnableCors("AllowOrigin")]
    [Route("api/[controller]")]
    [ApiController]
    public class PayplanController : ControllerBase
    {
        private readonly IPayplanInfrastructure _payplanInfrastructure;
        private readonly IMapper _mapper;

        public PayplanController(IPayplanInfrastructure payplanInfrastructure, IMapper mapper)
        {
            _payplanInfrastructure = payplanInfrastructure;
            _mapper = mapper;
        }

        //GET : api/Payplan
        [HttpGet]
        public async Task<List<PayplanResponse>> GetAllAsync()
        {
            var payplans = await _payplanInfrastructure.GetAllAsync();
            var payplansResponse = _mapper.Map<List<Payplan>, List<PayplanResponse>>(payplans);
            return payplansResponse;
        }

        //GET : api/Payplan/5
        [HttpGet("{id}")]
        public async Task<PayplanResponse> GetByIdAsync(int id)
        {
            var payplan = await _payplanInfrastructure.GetByIdAsync(id);
            var payplanResponse = _mapper.Map<Payplan, PayplanResponse>(payplan);
            return payplanResponse;
        }

        //POST : api/Payplan
        [HttpPost]
        public async Task CreateAsync([FromBody] PayplanRequest payplan)
        {
            if (ModelState.IsValid)
            {
                var payplanToMapped = _mapper.Map<PayplanRequest, Payplan>(payplan);
                await _payplanInfrastructure.CreateAsync(payplanToMapped);
            }
            else
            {
                StatusCode(400);
            }
        }
    }
}
