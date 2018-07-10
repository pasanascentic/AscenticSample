using Ascentic.Sample.Entities;

namespace Ascentic.Sample.ViewModel
{
    public interface IViewModel<TModel, TEntity> where TEntity : IEntity, new()
    {
        TEntity ToEntity();

        void ToModel(TEntity entity);
    }
}
