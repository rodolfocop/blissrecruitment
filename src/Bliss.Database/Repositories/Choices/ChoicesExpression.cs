using System.Linq.Expressions;
using Bliss.Domain.Models;
using Bliss.Model.Choices;

namespace Bliss.Database.Repositories.Choices
{
    public static class ChoicesExpression
    {
        public static Expression<Func<ChoicesEntity, ChoicesViewModel>> Model => entity => new ChoicesViewModel
        {
            Id = entity.Id,
            Choice = entity.Choice,
            Votes = entity.Votes
        };

    }
}
