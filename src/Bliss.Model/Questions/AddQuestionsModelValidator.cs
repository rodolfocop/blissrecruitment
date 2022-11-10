
namespace Bliss.Model.Questions
{
    public class AddQuestionsModelValidator : QuestionsValidator
    {
        public AddQuestionsModelValidator()
        {
            QuestionRequired();
            ImageUrlRequired();
            ThumbUrlRequired();
        }
    }
}
