using BlissRecruitment.Domain.Repository;

namespace BlissRecruitment.Domain.Questions
{
    public class QuestionStorer
    {
        private readonly IRepository<QuestionEntity> _questionRepository;
        private readonly IRepository<ChoiceEntity> _choiceRepository;

        public QuestionStorer(IRepository<QuestionEntity> questionRepository ,IRepository<ChoiceEntity> choiceEntity)
        {
            _questionRepository = questionRepository;
            _choiceRepository = choiceEntity;
        }

        public void Store(QuestionEntity question)
        {
            QuestionEntity storedQuestion = _questionRepository.GetById(question.Id, x => x.Choices);
            if (storedQuestion == null)
                _questionRepository.Create(question);
            else
            {
                storedQuestion.Update(question.Id, question.Question, question.ImageUrl, question.ThumbUrl, question.Choices);
                foreach(ChoiceEntity choice in question.Choices)
                {
                    var storedChoice = _choiceRepository.GetById(choice.Id);
                    storedChoice.Update(choice.Choice, choice.Votes);
                }
            }
        }
    }
}
