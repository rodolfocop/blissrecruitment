using Bliss.Database.Repositories.Questions;
using Bliss.Model.Questions;
using DotNetCore.EntityFrameworkCore;
using DotNetCore.Objects;
using DotNetCore.Results;
using DotNetCore.Validation;

namespace Bliss.Application.Questions
{
    public class QuestionsService : IQuestionsService
    {
        private readonly IQuestionsRepository _tipoAreasRepository;
        private readonly IQuestionsFactory _tipoAreasFactory;
        private readonly IUnitOfWork _unitOfWork;

        public QuestionsService(
            IQuestionsRepository tipoAreasRepository, 
            IUnitOfWork unitOfWork, 
            IQuestionsFactory tipoAreasFactory)
        {
            _tipoAreasRepository = tipoAreasRepository;
            _unitOfWork = unitOfWork;
            _tipoAreasFactory = tipoAreasFactory;
        }


        public async Task<IResult<int>> AddAsync(QuestionsViewModel modelView)
        {
            try
            {
                var validation = new AddQuestionsModelValidator().Validation(modelView);

                if (validation.Failed) return validation.Fail<int>();

                var modelEntity = _tipoAreasFactory.Create(modelView);

                await _tipoAreasRepository.AddAsync(modelEntity);

                await _unitOfWork.SaveChangesAsync();

                return modelEntity.Id.Success();

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<IResult> UpdateAsync(QuestionsViewModel model)
        {
            var validation = new AddQuestionsModelValidator().Validation(model);

            if (validation.Failed) return validation;

            var entity = await _tipoAreasRepository.GetAsync(model.Id);

            if (entity is null) return Result.Success();

            var modelEntity = _tipoAreasFactory.Edit(entity.Id, model);
            entity.Update(modelEntity);

            await _tipoAreasRepository.UpdateAsync(entity);

            await _unitOfWork.SaveChangesAsync();

            return Result.Success();
        }

        public async Task<QuestionsViewModel?> GetAsync(int id)
        {
            return await _tipoAreasRepository.GetModelAsync(id);
        }

        public Task<Grid<QuestionsViewModel>> GridAsync(GridParameters parameters)
        {
            return _tipoAreasRepository.GridAsync(parameters);
        }

        public async Task<IEnumerable<QuestionsViewModel>> ListAsync()
        {
            return await _tipoAreasRepository.ListModelAsync();
        }
    }
}
