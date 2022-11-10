using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Bliss.Database.Helpers
{
    public static class DbContextHelper
    {
        public static void UpdateChildAsync<TEntity, TId>(DbContext context,
        IEnumerable<TEntity> itensDb,
        IEnumerable<TEntity> itens,
        Func<TEntity, TEntity, bool> predicateDelete,
        Func<TEntity, TEntity, bool> predicateEdit)
        {
            foreach (var item in itensDb)
            {
                if (itens.All(c => predicateDelete.Invoke(c, item)))
                {
                    context.Entry(item).State = EntityState.Deleted;
                }
            }

            foreach (var item in itens)
            {
                if (itensDb.Any(c => predicateEdit.Invoke(c, item)))
                {
                    context.Entry(item).State = EntityState.Modified;
                }
                else
                {
                    context.Entry(item).State = EntityState.Added;
                }
            }
        }
    }
}