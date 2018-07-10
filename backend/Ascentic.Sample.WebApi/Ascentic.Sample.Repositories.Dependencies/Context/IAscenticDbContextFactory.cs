using System;
using System.Collections.Generic;
using System.Text;

namespace Ascentic.Sample.Repositories.Context
{
    public interface IAscenticDbContextFactory
    {
        EntityFrameworkDbContext Get();
    }
}
