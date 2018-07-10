namespace Ascentic.Sample.Services.Dependencies
{
    public abstract class BaseService : IBaseService
    {
        protected IUnitOfWork UnitOfWork { get; }
        
        protected BaseService(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }
    }
}
