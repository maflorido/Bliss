using System;

namespace BlissRecruitment.Domain.Questions
{
    public class ChoiceEntity
    {
        public int Id { get; private set; }
        public string Choice { get; private set; }
        public int Votes { get; set; }

        public ChoiceEntity(string choice, int votes)
        {
            Choice = choice ?? throw new Exception("Choice is required");
            Votes = votes;
        }

        public void Update(int votes)
        {
            Votes = votes;
        }
    }
}
