using Ascentic.Sample.Repositories;
using Ascentic.Sample.Repositories.Context;
using Ascentic.Sample.Repositories.Dependencies.EntityRepositories;
using Ascentic.Sample.Repositories.EntityRepositories;
using System.Threading.Tasks;

namespace Ascentic.Sample.Repositories.Dependencies
{
    public class AscenticUnitOfWork : IUnitOfWork
    {
        #region Fields

        private readonly IAscenticDbContextFactory _contextFactory;

        private EntityFrameworkDbContext _context;

        #endregion

        #region Properties

        protected EntityFrameworkDbContext Context => _context ?? (_context = _contextFactory.Get());

        public INewsRepository News { get; }

        #endregion

        #region Constructor

        public AscenticUnitOfWork(IAscenticDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;

            News = new NewsRepository(Context);
        }

        #endregion

        #region Public Methods

        public async Task<int> Commit()
        {
            return await Context.SaveChangesAsync();
        }

        #endregion
    }
}
