using Ascentic.Sample.Entities;
using Ascentic.Sample.Repositories.EntityRepositories;
using Microsoft.EntityFrameworkCore;

namespace Ascentic.Sample.Repositories.Dependencies.EntityRepositories
{
    public class NewsRepository : Repository<News>, INewsRepository
    {
        public NewsRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
