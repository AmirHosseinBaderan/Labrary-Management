using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using LIBRARY.DataLayer.Modles;

namespace LIBRARY.DataLayer.Servises
{
    public class GenericRepository<TEntity> where TEntity : class
    {
        private Library_DBEntities _db;
        private DbSet<TEntity> _dbset;

        public GenericRepository(Library_DBEntities Context)
        {
            _db = Context;
            _dbset = _db.Set<TEntity>();

        }

        public virtual void Delete(TEntity entity)
        {
            if(_db.Entry(entity).State == EntityState.Detached)
            {
                _dbset.Attach(entity);
            }

            _dbset.Remove(entity);
        }

        public virtual void Delete(object ID)
        {
            var Resualt = GetByID(ID);
            Delete(Resualt);
        }

        public virtual void Insert(TEntity entity)
        {
            _dbset.Add(entity);
        }

        public virtual void Updatae(TEntity entity)
        {
            if (_db.Entry(entity).State == EntityState.Detached)
            {
                _dbset.Attach(entity);
                _db.Entry(entity).State = EntityState.Modified;
            }
        }

        public virtual IEnumerable<TEntity> get(Expression<Func<TEntity, bool>> where = null)
        {
            IQueryable<TEntity> query = _dbset;
            if (where != null)
            {
                query = query.Where(where);
            }

            return query.ToList();
        }

        public virtual TEntity GetByID(object ID)
        {
            return _dbset.Find(ID);
        }

       
    }
}
