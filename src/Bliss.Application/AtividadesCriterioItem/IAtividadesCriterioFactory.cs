using Metajud.Application.Base;
using Metajud.Model.AtividadesCriterioItem;
using MetaJud.Domain.Models;

namespace Metajud.Application.AtividadesCriterioItemItem
{
    public interface IAtividadesCriterioItemFactory : IBaseFactory<AtividadesCriterioItemEntity, AtividadesCriterioItemViewModel>
    {
        public AtividadesCriterioItemEntity Create(AtividadesCriterioItemViewModel viewModel, Guid idAtividadeCriterio);
    }
}
