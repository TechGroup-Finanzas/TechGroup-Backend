using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using TechGroup.API.TechGroup.Questions.Request;
using TechGroup.API.TechGroup.Questions.Response;
using TechGroup.Domain.TechGroup.Questions.Interfaces;
using TechGroup.Infrastructure.TechGroup.Questions.Interfaces;
using TechGroup.Infrastructure.TechGroup.Questions.Models;

namespace TechGroup.API.TechGroup.Questions.Controllers
{
    [EnableCors("AllowOrigin")]
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private readonly IQuestionDomain _questionDomain;
        private readonly IMapper _mapper;
        private readonly IQuestionInfrastructure _questionInfrastructure;
        
        public QuestionController(IQuestionDomain questionDomain, IMapper mapper, IQuestionInfrastructure questionInfrastructure)
        {
            _questionDomain = questionDomain;
            _mapper = mapper;
            _questionInfrastructure = questionInfrastructure;
        }
        
        //GET : api/Question
        [HttpGet]
        public async Task<List<QuestionResponse>> GetAllAsync()
        {
            var questions = await _questionInfrastructure.GetAllAsync();
            var questionsResponse = _mapper.Map<List<Question>, List<QuestionResponse>>(questions);
            return questionsResponse;
        }
        
        //GET : api/Question/{id}
        [HttpGet("{id}")]
        public async Task<QuestionResponse> GetByIdAsync(int id)
        {
            var question = await _questionInfrastructure.GetByIdAsync(id);
            var questionResponse = _mapper.Map<Question, QuestionResponse>(question);
            return questionResponse;
        }
        
        //POST : api/Question
        [HttpPost]
        public async Task CreateAsync([FromBody] QuestionRequest question)
        {
            if (ModelState.IsValid)
            {
                var questionToMapped = _mapper.Map<QuestionRequest, Question>(question);
                await _questionDomain.SaveAsync(questionToMapped);
            }
            else
            {
                StatusCode(400);
            }
        }
        
        //PUT : api/Question/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] QuestionRequest question)
        {
            var questionToMapped = _mapper.Map<QuestionRequest, Question>(question);
            var questionUpdated = await _questionDomain.UpdateAsync(id, questionToMapped);
            if (questionUpdated)
            {
                return Ok();
            }

            return BadRequest();
        }
        
        //DELETE : api/Question/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var questionDeleted = await _questionDomain.DeleteAsync(id);
            if (questionDeleted)
            {
                return Ok();
            }

            return BadRequest();
        }
    }
}
