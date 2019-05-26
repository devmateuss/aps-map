using System.Collections.Generic;
using System.Threading.Tasks;
using Aps.Domain;

namespace Aps.Repository
{
    public interface IApsRepository
    {
        //General Methods
         void Add<T>(T entity ) where T: class ;
         void Updade<T>(T entity ) where T: class ;
         void Delete<T>(T entity ) where T: class ;

         Task<bool> SaveChangesAsync();

         //Spesific Students Methods
         Task<Student[]> GetAllStudentsAsync();
         Task<Student> GetAllStudentsAsyncById(int id);

    }
}