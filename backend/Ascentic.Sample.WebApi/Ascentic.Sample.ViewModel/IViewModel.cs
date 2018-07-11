using Ascentic.Sample.Entities;

namespace Ascentic.Sample.ViewModel
{
    public interface IViewModel<TModel, TEntity> where TEntity : IEntity, new()
    {
        //// Auto Mapper take cares of this implementation
        //TEntity ToEntity();

        //void ToModel(TEntity entity);
    }
}
