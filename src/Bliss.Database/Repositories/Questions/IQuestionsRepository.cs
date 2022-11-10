using Bliss.Domain.Models;
using Bliss.Model.Questions;
using DotNetCore.Objects;
using DotNetCore.Repositories;

namespace Bliss.Database.Repositories.Questions
{
    public interface IQuestionsRepository : IRepository<QuestionsEntity>
    {
        Task<QuestionsViewModel?> GetModelAsync(int id);
        Task<Grid<QuestionsViewModel>> GridAsync(GridParameters parameters);
        Task<IEnumerable<QuestionsViewModel>> ListModelAsync();
        Task UpdateChildAsync(QuestionsEntity entity);

    }
}
