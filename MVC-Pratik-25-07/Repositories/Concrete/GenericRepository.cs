using MVC_Pratik_25_07.AppDbContext;
using MVC_Pratik_25_07.Entities.Abstract;
using MVC_Pratik_25_07.Repositories.Abstract;
using System;
using System.Linq;

namespace MVC_Pratik_25_07.Repositories.Concrete
{
    public class GenericRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly ApplicationDbContext db;

        public GenericRepository(ApplicationDbContext db)
        {
            this.db = db;
        }
        public bool Add(T entity)
        {
             db.Set<T>().Add(entity);
            return db.SaveChanges() > 0;
        }

        public bool Delete(T entity)
        {
            try
            {
                db.Set<T>().Remove(entity);
                return db.SaveChanges() > 0;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public System.Collections.Generic.IEnumerable<T> GetAll()
        {
            return db.Set<T>();
        }

        public T GetById(int id)
        {
            return db.Set<T>().FirstOrDefault(a => a.Id == id);
            //return db.Set<T>().Find(id); burası yukarıda implemante yerini class tutarsan kullanacağın yapı.Çünkü gönderdiğin her classın id'si olmak zorunda değil
        }

        public System.Collections.Generic.IEnumerable<T> GetWhere(System.Linq.Expressions.Expression<System.Func<T, bool>> predicate)
        {
            return db.Set<T>().Where(predicate);
        }

        public T SingleOrDefault(System.Linq.Expressions.Expression<System.Func<T, bool>> predicate)
        {
            return db.Set<T>().SingleOrDefault(predicate);
        }

        public bool Update(T entity)
        {
            try
            {
                //Update metodu içine gönderilen entity'de id varsa ilgili id'deki yapıyı update eder , id yok ise add gibi çalışır.. Bu sebeple Tek bir AddorUpdate metodu oluşturulabilir
                db.Set<T>().Update(entity);
                return db.SaveChanges() > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
