using Bliss.Domain.Models;
using Bliss.Model.Choices;

namespace Bliss.Application.Choices;

public class ChoicesFactory : IChoicesFactory
{

    public ChoicesEntity Create(ChoicesViewModel viewModel)
    {
        return new ChoicesEntity(
            Convert.ToInt32(viewModel.Id),
            viewModel.Choice,
            viewModel.Votes
        );
    }
}