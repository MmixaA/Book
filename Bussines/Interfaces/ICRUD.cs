using Bussines.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussines.Interfaces
{
    public interface ICrud<TModel,TCreateModel> where TModel : class
    {
        Task<IEnumerable<TModel>> GetAllAsync();

        Task<TModel> GetByIdAsync(int id);

        Task UpdateAsync(TModel model);

        Task DeleteAsync(int modelId);

        Task AddAsync(TCreateModel model);
    }
}
