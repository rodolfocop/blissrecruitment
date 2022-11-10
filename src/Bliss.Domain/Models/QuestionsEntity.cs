using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DotNetCore.Domain;

namespace Bliss.Domain.Models
{
    public class QuestionsEntity : Entity<int>
    {
        public QuestionsEntity
        (
            int id,
            int idQuestions,
            string imageUrl,
            string thumbUrl,
            string question,
            DateTimeOffset publishedAt,
            ICollection<ChoicesEntity> choises
        )
        {
            Id = id;
            ImageUrl = imageUrl;
            IdQuestions = idQuestions;
            ThumbUrl = thumbUrl;
            Question = question;
            PublishedAt = publishedAt;
            Choises = choises;
        }
        [Key]
        public int Id { get; set; }

        public int IdQuestions { get; set; }
        public string ImageUrl { get; set; }
        public string ThumbUrl { get; set; }
        public string Question { get; set; }
        public DateTimeOffset PublishedAt { get; private set; }

        [ForeignKey("IdQuestion")]
        public virtual ICollection<ChoicesEntity> Choises { get; set; }


        public void Update(QuestionsEntity entity)
        {
            Id = entity.Id;
            IdQuestions = entity.IdQuestions;
            ImageUrl = entity.ImageUrl;
            ThumbUrl = entity.ThumbUrl;
            Question = entity.Question;
            PublishedAt = entity.PublishedAt;
            Choises = entity.Choises;
        }
    }
}
