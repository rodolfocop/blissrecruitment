using Bliss.Model.Choices;
namespace Bliss.Model.Questions;

public class QuestionsViewModel
{
    public int? Id { get; set; }
    public int IdQuestions { get; set; }
    public string ImageUrl { get; set; }
    public string ThumbUrl { get; set; }
    public string Question { get; set; }
    public DateTimeOffset PublishedAt { get; set; } = DateTimeOffset.Now;

    public IEnumerable<ChoicesViewModel> Choices { get; set; }
}