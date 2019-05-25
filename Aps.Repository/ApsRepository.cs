using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aps.Domain;
using Microsoft.EntityFrameworkCore;

namespace Aps.Repository
{
    public class ApsRepository : IApsRepository
    {
        public ApsContext _context { get; }
        public ApsRepository(ApsContext context)
        {
            _context = context;

        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Updade<T>(T entity) where T : class
        {
             _context.Update(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
             _context.Remove(entity);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0; 
        }

        public async Task<Student[]> GetAllStudentsAsync()
        {
            var reults = await _context.Students.ToArrayAsync();

            return reults;
        }
        public async Task<Student> GetAllStudentsAsyncById(int StudentId)
        {
            var result = await _context.Students.FirstOrDefaultAsync(student => student.Id == StudentId);

            return result;
        }

    }
}