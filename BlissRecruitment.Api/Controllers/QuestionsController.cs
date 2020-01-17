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

        public QuestionsController(IRepository<QuestionEntity> questionRepository)
        {
            _questionRepository = questionRepository;
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
    }
}