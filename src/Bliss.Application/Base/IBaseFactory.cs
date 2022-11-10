namespace Bliss.Application.Base
{
    public interface IBaseFactory<out TEntity, in TModel>
    {
        TEntity Create(TModel tModel);
    }
}
