using Bliss.Database.Context;
using Bliss.Database.Helpers;
using Bliss.Domain.Models;
using Bliss.Model.Questions;
using DotNetCore.EntityFrameworkCore;
using DotNetCore.Objects;
using Microsoft.EntityFrameworkCore;

namespace Bliss.Database.Repositories.Questions
{
    public sealed class QuestionsRepository : EFRepository<QuestionsEntity>, IQuestionsRepository
    {

        private readonly QuestionsContext _context;
        private IQueryable<ChoicesEntity> ChoiceCrud => _context.Set<ChoicesEntity>();

        public QuestionsRepository(QuestionsContext context) : base(context)
        {
            _context = context;
        }

        public async Task<QuestionsViewModel?> GetModelAsync(int id)
        {
            return await Queryable.Where(QuestionsExpression.Id(id)).Select(QuestionsExpression.Model).SingleOrDefaultAsync();
        }

        public async Task<Grid<QuestionsViewModel>> GridAsync(GridParameters parameters)
        {
            return await Queryable.Select(QuestionsExpression.Model).GridAsync(parameters);
        }

        public async Task<IEnumerable<QuestionsViewModel>> ListModelAsync()
        {
            return await Queryable
                .Include(c => c.Choises)
                .Select(QuestionsExpression.Model)
                .ToListAsync();
        }

        public async Task UpdateChildAsync(QuestionsEntity entity)
        {
            var questionsDb = await ChoiceCrud
                .Include(c => c.Questions)
                .Where(x => x.IdQuestion == entity.Id)
                .ToListAsync();

            DbContextHelper.UpdateChildAsync<ChoicesEntity, int>(_context, questionsDb, entity.Choises,
                (a, b) => a.Id != b.Id,
                (a, b) => a.Id == b.Id);

            //foreach (var itemChoise in entity.Choises)
            //{
            //    if (questionsDb.Any(x => x.Id == itemChoise.Id))
            //    {
            //        _context.Entry(itemChoise).State = EntityState.Modified;
            //    }
            //    else
            //    {
            //        _context.Entry(itemChoise).State = EntityState.Added;
            //    }
            //}

            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}
