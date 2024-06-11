using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using TechGroup.API.TechGroup.Answers.Request;
using TechGroup.API.TechGroup.Answers.Response;
using TechGroup.Domain.TechGroup.Answers.Interfaces;
using TechGroup.Infrastructure.TechGroup.Answers.Interfaces;
using TechGroup.Infrastructure.TechGroup.Answers.Models;

namespace TechGroup.API.TechGroup.Answers.Controllers
{
    [EnableCors("AllowOrigin")]
    [Route("api/[controller]")]
    [ApiController]
    public class AnswerController: ControllerBase
    {
        private readonly IAnswerDomain _answerDomain;
        private readonly IMapper _mapper;
        private readonly IAnswerInfrastructure _answerInfrastructure;
        
        public AnswerController(IAnswerDomain answerDomain, IMapper mapper, IAnswerInfrastructure answerInfrastructure)
        {
            _answerDomain = answerDomain;
            _mapper = mapper;
            _answerInfrastructure = answerInfrastructure;
        }
        
        //GET : api/Answer
        [HttpGet]
        public async Task<List<AnswerResponse>> GetAllAsync()
        {
            var answers = await _answerInfrastructure.GetAllAsync();
            var answersResponse = _mapper.Map<List<Answer>, List<AnswerResponse>>(answers);
            return answersResponse;
        }
        
        //GET : api/Answer/{id}
        [HttpGet("{id}")]
        public async Task<AnswerResponse> GetByIdAsync(int id)
        {
            var answer = await _answerInfrastructure.GetByIdAsync(id);
            var answerResponse = _mapper.Map<Answer, AnswerResponse>(answer);
            return answerResponse;
        }
        
        //POST : api/Answer
        [HttpPost]
        public async Task CreateAsync([FromBody] AnswerRequest answer)
        {
            if (ModelState.IsValid)
            {
                var answerToMapped = _mapper.Map<AnswerRequest, Answer>(answer);
                await _answerDomain.SaveAsync(answerToMapped);
            }
            else
            {
                StatusCode(400);
            }
        }
        
        //PUT : api/Answer/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] AnswerRequest answer)
        {
            var answerToMapped = _mapper.Map<AnswerRequest, Answer>(answer);
            var result = await _answerDomain.UpdateAsync(id, answerToMapped);
            if (result)
            {
                return Ok();
            }

            return BadRequest();
        }
        
        //DELETE : api/Answer/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var answerDeleted = await _answerDomain.DeleteAsync(id);
            if (answerDeleted)
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}