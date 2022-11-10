
namespace Bliss.Model.Choices
{
    public class AddChoicesModelValidator : ChoicesValidator
    {
        public AddChoicesModelValidator()
        {
            ChoiceRequired();
            VotesRequired();
        }
    }
}
