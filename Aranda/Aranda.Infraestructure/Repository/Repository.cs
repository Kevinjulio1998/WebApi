using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Aranda.Infraestructure.Repository
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> whereCondition = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = "");
        Task<bool> CreateAsync(T entity);


        Task<bool> Update(T entity, dynamic key);
        bool Delete(T entity);

    }

    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly IUnitOfWork _unitOfWork;
        public Repository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public async Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> whereCondition = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = "")
        {
            IQueryable<T> query = _unitOfWork.Context.Set<T>();

            if (whereCondition != null)
            {
                query = query.Where(whereCondition);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return await orderBy(query).ToListAsync();
            }

            return await query.ToListAsync();
        }

        public async Task<bool> CreateAsync(T entity)
        {
            bool created = false;

            var save = await _unitOfWork.Context.Set<T>().AddAsync(entity);

            if (save != null)
                created = true;
            _unitOfWork.Commit();
            return created;
        }

        public  bool Delete(T entity)
        {
            bool created = false;

            var save =  _unitOfWork.Context.Set<T>().Remove(entity);

            if (save != null)
                created = true;
            _unitOfWork.Commit();
            return created;
        }
        public async Task<bool> Update(T entity, dynamic key)
        {
            bool updated = false;

            T exist = await _unitOfWork.Context.Set<T>().FindAsync(key);

            if (exist != null)
            {
                _unitOfWork.Context.Entry(exist).CurrentValues.SetValues(entity);
                updated = true;
                _unitOfWork.Commit();
            }

            return updated;
        }


    }
}
