using FluentValidation;

namespace Bliss.Model.Questions;

public abstract class QuestionsValidator : AbstractValidator<QuestionsViewModel>
{
    public void QuestionRequired() => RuleFor(instituicao => instituicao.Question)
        .NotEmpty()
        .WithMessage("Question is a required field!");

    public void ImageUrlRequired() => RuleFor(instituicao => instituicao.ImageUrl)
        .NotEmpty()
        .WithMessage("Image is a required field!");

   
    public void ThumbUrlRequired() => RuleFor(instituicao => instituicao.ThumbUrl)
        .NotEmpty()
        .WithMessage("The thumb is a required field!");

}