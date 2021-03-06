﻿using System;
using System.Threading.Tasks;

namespace Ascentic.Sample.Services.Dependencies
{
    public abstract class BaseService : IBaseService
    {
        protected BaseService()
        {
        }

        #region Protected Methods

        protected async Task<dynamic> ExecuteBlockAsync(Func<Task<dynamic>> func, Func<Exception,dynamic> onerror = null)
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
