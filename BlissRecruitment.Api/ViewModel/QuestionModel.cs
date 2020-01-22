using System;
using System.Collections.Generic;

namespace BlissRecruitment.Api.ViewModel
{
    public class QuestionModel
    {
        public int Id { get; set; }
        public string Question { get;  set; }

        public string ImageUrl { get; set; }

        public string ThumbUrl { get; set; }

        public DateTime PublishedAt { get; set; }

        public ICollection<ChoiceModel> Choices { get; set; }
    }
}
