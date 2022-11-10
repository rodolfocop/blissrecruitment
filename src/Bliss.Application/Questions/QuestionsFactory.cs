using Bliss.Application.Choices;
using Bliss.Domain.Models;
using Bliss.Model.Questions;

namespace Bliss.Application.Questions;

public class QuestionsFactory : IQuestionsFactory
{
    private readonly IChoicesFactory _choicesFactory;

    public QuestionsFactory(IChoicesFactory choicesFactory)
    {
        _choicesFactory = choicesFactory;
    }

    public QuestionsEntity Create(QuestionsViewModel viewModel)
    {
        return new QuestionsEntity(
            Convert.ToInt32(viewModel.Id),
            viewModel.IdQuestions,
            viewModel.ImageUrl,
            viewModel.ThumbUrl,
            viewModel.Question,
            viewModel.PublishedAt,
            viewModel.Choices.Select(_choicesFactory.Create).ToList());
    }

    public QuestionsEntity Edit(int entityId, QuestionsViewModel viewModel)
    {
        var itemQuestion = Create(viewModel);
        itemQuestion.Id = entityId;
        return itemQuestion;
    }
}