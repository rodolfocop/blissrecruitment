using MassTransit;
using Metajud.Model.AtividadesCriterioItem;
using MetaJud.Domain.Models;

namespace Metajud.Application.AtividadesCriterioItemItem;

public class AtividadesCriterioItemFactory : IAtividadesCriterioItemFactory
{
    public AtividadesCriterioItemEntity Create(AtividadesCriterioItemViewModel viewModel)
    {
        return new AtividadesCriterioItemEntity(
            new Guid(NewId.Next().ToString("D").ToUpperInvariant()),
            viewModel.IdAtividadesCriterio ?? Guid.Empty,
            viewModel.IdGrupoCriterio
            );
    }

    public AtividadesCriterioItemEntity Create(AtividadesCriterioItemViewModel viewModel, Guid idAtividadeCriterio)
    {
        return new AtividadesCriterioItemEntity(
            new Guid(NewId.Next().ToString("D").ToUpperInvariant()),
            idAtividadeCriterio,
            viewModel.IdGrupoCriterio
            );
    }
}