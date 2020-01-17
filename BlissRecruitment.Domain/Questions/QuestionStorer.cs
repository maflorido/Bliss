using BlissRecruitment.Domain.Repository;

namespace BlissRecruitment.Domain.Questions
{
    public class QuestionStorer
    {
        private readonly IRepository<QuestionEntity> _questionRepository;
        private readonly IRepository<ChoiceEntity> _choiceEntity;

        public QuestionStorer(IRepository<QuestionEntity> questionRepository ,IRepository<ChoiceEntity> choiceEntity)
        {
            _questionRepository = questionRepository;
            _choiceEntity = choiceEntity;
        }

        public void Store(QuestionEntity question)
        {
            QuestionEntity storedQuestion = _questionRepository.GetById(question.Id);
            if(storedQuestion == null)
                _questionRepository.Create(question);
            else
                storedQuestion.Update(question.Question, question.ImageUrl, question.ThumbUrl, question.Choices);
        }
    }
}
