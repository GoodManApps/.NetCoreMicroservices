using Actio.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actio.Domain.Repositories
{
    public interface ICategoryRepository
    {
        Task<Category> GetAsync(string name);

        Task<IEnumerable<Category>> BrowseAsync();

        Task AddAsync(Category category);
    }
}
