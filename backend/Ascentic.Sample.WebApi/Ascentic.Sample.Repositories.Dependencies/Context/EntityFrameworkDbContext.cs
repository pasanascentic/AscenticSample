using Ascentic.Sample.Entities;
using Microsoft.EntityFrameworkCore;

namespace Ascentic.Sample.Repositories.Context
{
    public class EntityFrameworkDbContext : DbContext
    {
        // Do a direct migration need to have a connection string
        #region Constant

        const string ConnectionString = "";

        #endregion

        #region DBSets

        public virtual DbSet<News> Users { get; set; }

        #endregion

        #region Constructor

        public EntityFrameworkDbContext()
            : base(new DbContextOptionsBuilder<EntityFrameworkDbContext>().UseSqlServer(ConnectionString).Options)
        {

        }

        public EntityFrameworkDbContext(DbContextOptions<EntityFrameworkDbContext> options)
            : base(options)
        {
        }

        #endregion

        #region Overrides

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        #endregion
    }
}
