using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Ascentic.Sample.Repositories.Context
{
    public class AscenticDbContextFactory : IAscenticDbContextFactory
    {
        #region Const

        const string ConnectionStringName = "DBCon";

        const string ConnectionString = "Server=tcp:beautylankadb.database.windows.net,1433;Initial Catalog=PlugDB;Persist Security Info=False;User ID=pasanw;Password=Donkey@1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        #endregion

        #region Fields

        private EntityFrameworkDbContext _context;

        private IConfiguration configuration;

        #endregion

        #region Constructor

        public AscenticDbContextFactory(IConfiguration Configuration)
        {
            configuration = Configuration;
        }

        public AscenticDbContextFactory()
        {
            configuration = null;
        }

        #endregion

        #region Implmentation

        public EntityFrameworkDbContext Get()
        {
            if (_context == null)
            {
                InitialiseContext();
            }

            return _context;
        }

        #endregion

        #region Helpers

        private void InitialiseContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<EntityFrameworkDbContext>();

            if (configuration == null)
            {
                optionsBuilder.UseSqlServer(ConnectionString);
            }
            else
            {
                optionsBuilder.UseSqlServer(configuration.GetConnectionString(ConnectionStringName));
            }

            _context = new EntityFrameworkDbContext(optionsBuilder.Options);
        }

        #endregion
    }
}
