namespace Bliss.Model.Choices
{
    public class ChoicesViewModel
    {
        public int? Id { get; set; }
        public string Choice { get; set; }
        public int Votes { get; set; } = 0;
    }
}
