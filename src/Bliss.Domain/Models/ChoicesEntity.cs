using DotNetCore.Domain;
using System.ComponentModel.DataAnnotations;

namespace Bliss.Domain.Models
{
    public class ChoicesEntity : Entity<int>
    {
        public ChoicesEntity(int id, string choice, int votes)
        {
            Id = id;
            Choice = choice;
            Votes = votes;
        }

        [Key]
        public int Id { get; set; }

        public int IdQuestion { get; set; }
        public string Choice { get; set; }
        public int Votes { get; set; }

        public QuestionsEntity Questions { get; set; }

        public void Update(int votes)
        {
            Votes = votes;
        }
    }
}
