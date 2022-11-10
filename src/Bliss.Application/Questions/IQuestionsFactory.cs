using Bliss.Application.Base;
using Bliss.Domain.Models;
using Bliss.Model.Questions;

namespace Bliss.Application.Questions
{
    public interface IQuestionsFactory : IBaseFactory<QuestionsEntity, QuestionsViewModel>
    {
        QuestionsEntity Edit(int entityId, QuestionsViewModel model);
    }
}
