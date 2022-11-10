using DotNetCore.Objects;
using DotNetCore.Results;

namespace Bliss.Application.Base
{
    public interface IBaseServices<T>
    {
        Task<IResult<int>> AddAsync(T model);
        Task<IResult> UpdateAsync(T model);

        Task<T?> GetAsync(int id);
        Task<Grid<T>> GridAsync(GridParameters parameters);
        Task<IEnumerable<T>> ListAsync();
    }
}
