using FluentValidation;

namespace Bliss.Model.Choices;

public abstract class ChoicesValidator : AbstractValidator<ChoicesViewModel>
{
    public void ChoiceRequired() => RuleFor(fluxoProcesual => fluxoProcesual.Choice)
        .NotEmpty()
        .WithMessage("Choose is a required field!");

    public void VotesRequired() => RuleFor(fluxoProcesual => fluxoProcesual.Votes)
        .NotEmpty()
        .WithMessage("Votes is a required field");
    
    
}