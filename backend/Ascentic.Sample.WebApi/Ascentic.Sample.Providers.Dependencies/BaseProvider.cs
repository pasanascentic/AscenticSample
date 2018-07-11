using Ascentic.Sample.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ascentic.Sample.Providers.Dependencies
{
    public class BaseProvider : IBaseProvider
    {
        protected IUnitOfWork UnitOfWork { get; }

        protected BaseProvider(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        #region Protected Methods

        protected async Task<dynamic> ExecuteBlockAsync(Func<Task<dynamic>> func, Func<Exception, dynamic> onerror = null)
        {
            try
            {
                return await func.Invoke();
            }
            catch (Exception exception)
            {
                // TODO: Log the error

                onerror?.Invoke(exception);

                throw exception;
            }
        }

        protected async Task ExecuteBlockAsync(Func<Task> func, Action<Exception> onerror = null)
        {
            try
            {
                await func.Invoke();
            }
            catch (Exception exception)
            {
                // TODO: Log the error

                onerror?.Invoke(exception);

                throw exception;
            }
        }

        #endregion
    }
}
