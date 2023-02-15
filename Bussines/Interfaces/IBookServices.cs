using Bussines.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussines.Interfaces
{
    public interface IBookService : ICrud<BookDTO,BookCreateModel>
    {
        Task<IEnumerable<BookDTO>> GetByFilterAsync(string filterSearch);
    }
}
