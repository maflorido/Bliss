using System;
using System.Collections.Generic;
using System.Linq;

namespace BlissRecruitment.Domain.Questions
{
    public class QuestionEntity : BaseEntity
    {

        public string Question { get; private set; }

        public string ImageUrl { get; private set; }

        public string ThumbUrl { get; private set; }

        public DateTime PublishedAt { get; private set; }

        public ICollection<ChoiceEntity> Choices { get; private set; }

        protected QuestionEntity() { }

        public QuestionEntity(int id, string question, string imageUrl, string thumbUrl, ICollection<ChoiceEntity> choices)
        {
            Validate(question, imageUrl, thumbUrl, choices);
            SetValues(id, question, imageUrl, thumbUrl, choices);
            
        }

        public void Update(int id, string question, string imageUrl, string thumbUrl, ICollection<ChoiceEntity> choices)
        {
            Validate(question, imageUrl, thumbUrl, choices);
            SetValues(id, question, imageUrl, thumbUrl);            
        }

        private void Validate(string question, string imageUrl, string thumbUrl, ICollection<ChoiceEntity> choices)
        {
            Question = question ?? throw new DomainException("Question is required");
            ImageUrl = imageUrl ?? throw new DomainException("Image Url is required");
            ThumbUrl = thumbUrl ?? throw new DomainException("Thumb Url is required");
            if (choices == null || !choices.Any())
                throw new DomainException("Choices is required");
        }

        private void SetValues(int id, string question, string imageUrl, string thumbUrl, ICollection<ChoiceEntity> choices = null)
        {
            Id = id;
            Question = question;
            ImageUrl = imageUrl;
            ThumbUrl = thumbUrl;
            if (choices != null)
                Choices = new List<ChoiceEntity>(choices);
            PublishedAt = DateTime.Now;
        }
    }
}
