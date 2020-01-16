﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace BlissRecruitment.Domain.Questions
{
    public class QuestionEntity
    {
        public int Id { get; private set; }

        public string Question { get; private set; }

        public string ImageUrl { get; private set; }

        public string ThumbUrl { get; private set; }

        public DateTime PublishedAt { get; private set; }

        public IEnumerable<ChoiceEntity> Choices { get; private set; }

        public QuestionEntity(string question, string imageUrl, string thumbUrl, List<ChoiceEntity> choices)
        {
            Validate(question, imageUrl, thumbUrl, choices);
            SetValues(question, imageUrl, thumbUrl, choices);
        }

        public void Update(string question, string imageUrl, string thumbUrl, List<ChoiceEntity> choices)
        {
            Validate(question, imageUrl, thumbUrl, choices);
            SetValues(question, imageUrl, thumbUrl, choices);
        }

        private void Validate(string question, string imageUrl, string thumbUrl, List<ChoiceEntity> choices)
        {
            Question = question ?? throw new Exception("Question is required");
            ImageUrl = imageUrl ?? throw new Exception("Image Url is required");
            ThumbUrl = thumbUrl ?? throw new Exception("Thumb Url is required");
            if (choices == null || !choices.Any())
                throw new Exception("Choices is required");
        }

        private void SetValues(string question, string imageUrl, string thumbUrl, List<ChoiceEntity> choices)
        {
            Question = question;
            ImageUrl = imageUrl;
            ThumbUrl = thumbUrl;
            Choices = new List<ChoiceEntity>(choices);
        }
    }
}