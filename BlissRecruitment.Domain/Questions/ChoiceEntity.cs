using System;

namespace BlissRecruitment.Domain.Questions
{
    public class ChoiceEntity : BaseEntity
    {
        public string Choice { get; private set; }
        public int Votes { get; set; }

        public ChoiceEntity(int id, string choice, int votes)
        {
            Id = id;
            Choice = choice ?? throw new DomainException("Choice is required");
            Votes = votes;
        }

        public void Update(string choice, int votes)
        {
            Choice = choice;
            Votes = votes;
        }
    }
}
