using BlissRecruitment.Domain.Questions;
using BlissRecruitment.Domain.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BlissRecruitment.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        private readonly IRepository<QuestionEntity> _questionRepository;
        private readonly QuestionStorer _questionStorer;

        public QuestionsController(IRepository<QuestionEntity> questionRepository, QuestionStorer questionStorer)
        {
            _questionRepository = questionRepository;
            _questionStorer = questionStorer;
        }

        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<QuestionEntity> questions = _questionRepository.List();
            return Ok(questions);
        }

        [HttpGet("questions?question_id={questionId}")]
        public IActionResult Get(int questionId)
        {
            QuestionEntity questions = _questionRepository.GetById(questionId);
            return Ok(questions);
        }

        [HttpPost]
        public IActionResult Post()
        {
            return Ok();
        }
        
    }
}