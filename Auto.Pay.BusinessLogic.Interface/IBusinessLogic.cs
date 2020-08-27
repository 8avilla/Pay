using Auto.Pay.BusinessLogic.Entities;
using System.Collections.Generic;

namespace Auto.Pay.BusinessLogic.Interface
{
    public interface IBusinessLogic
    {

        //EntityBusinessLogic FindByIdConDependencia(int id);

        //IEnumerable<EntityBusinessLogic> FindAllConDependencia();

        IEnumerable<EntityBusinessLogic> FindAll();

        EntityBusinessLogic FindById(int id);

        EntityBusinessLogic Add(EntityBusinessLogic entity);

        IEnumerable<EntityBusinessLogic> AddRange(IEnumerable<EntityBusinessLogic> listaEntity);

        EntityBusinessLogic Update(EntityBusinessLogic entity);
        IEnumerable<EntityBusinessLogic> UpdateRange(IEnumerable<EntityBusinessLogic> listaEntity);
        bool Exists(int id);

        bool Exists();

        bool Exists(EntityBusinessLogic entity);

        EntityBusinessLogic Remove(int id);

        EntityBusinessLogic Remove(EntityBusinessLogic entity);

        IEnumerable<EntityBusinessLogic> RemoveRange(IEnumerable<EntityBusinessLogic> listaEntity);

        IEnumerable<EntityBusinessLogic> RemoveRange(IEnumerable<int> listaId);

        IEnumerable<EntityBusinessLogic> FindRemoved();
    }
}
