using System.Linq.Expressions;
using Bliss.Database.Repositories.Choices;
using Bliss.Domain.Models;
using Bliss.Model.Questions;

namespace Bliss.Database.Repositories.Questions
{
    public static class QuestionsExpression
    {

        public static Expression<Func<QuestionsEntity, QuestionsViewModel>> Model => entity => new QuestionsViewModel
        {
            Id= entity.Id,
            ImageUrl = entity.ImageUrl,
            ThumbUrl = entity.ThumbUrl,
            Question = entity.Question,
            PublishedAt = entity.PublishedAt,
            Choices = entity.Choises.AsQueryable().Select(ChoicesExpression.Model).ToList(),
        };

        public static Expression<Func<QuestionsEntity, bool>> Id(int id)
        {
            return user => user.Id == id;
        }
    }
}
