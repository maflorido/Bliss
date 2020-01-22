using BlissRecruitment.Api.Infra.CustomParameters;
using BlissRecruitment.Api.ViewModel;
using BlissRecruitment.Domain;
using BlissRecruitment.Domain.Questions;
using BlissRecruitment.Domain.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

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
        [RequireParameter("question_filter")]
        public IActionResult GetQuestionsByFilter(string question_filter)
        {
            IEnumerable<QuestionEntity> questions = _questionRepository.List(x => x.Choices);
            return Ok(questions);
        }

        [HttpGet]
        [RequireParameter("question_id")]
        public IActionResult GetQuestionById(int question_id)
        {
            QuestionEntity questions = _questionRepository.GetById(question_id, x => x.Choices);
            return Ok(questions);
        }

        [HttpPost]
        public IActionResult Post(QuestionModel question)
        {
            try
            {
                QuestionEntity questionEntity = new QuestionEntity(question.Id, question.Question, question.ImageUrl, question.ThumbUrl, question.Choices.Select(x => new ChoiceEntity(x.Id, x.Choice, x.Votes)).ToList());
                _questionStorer.Store(questionEntity);
                return StatusCode(201, questionEntity);
            }
            catch (DomainException)
            {
                return BadRequest(new { status = "Bad request. All fields are mandatory" });
            }
        }

        [HttpPut]
        public IActionResult Put(QuestionModel question)
        {
            try
            {
                QuestionEntity questionEntity = new QuestionEntity(question.Id, question.Question, question.ImageUrl, question.ThumbUrl, question.Choices.Select(x => new ChoiceEntity(x.Id, x.Choice, x.Votes)).ToList());
                _questionStorer.Store(questionEntity);
                return StatusCode(201, questionEntity);
            }
            catch (DomainException)
            {
                return BadRequest(new { status = "Bad request. All fields are mandatory" });
            }
        }

    }
}