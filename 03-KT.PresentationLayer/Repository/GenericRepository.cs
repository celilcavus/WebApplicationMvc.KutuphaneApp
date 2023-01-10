using _02_KT.DataModel.Model;
using _03_KT.PresentationLayer.Interface;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace _03_KT.PresentationLayer.Repository
{
    public class GenericRepository<T> : IInsert<T>, IUpdate<T>, IRemove<T>, IToList<T> where T : class
    {
        AppDbContext app = new AppDbContext();

        DbSet<T> db;
        public GenericRepository()
        {
            db = app.Set<T>();
        }
        public void Insert(T item)
        {
            db.Add(item);
            app.SaveChanges();
        }

        public HashSet<T> List()
        {
            return db.ToHashSet();
        }

        public void Remove(T item)
        {
            
            db.Remove(item);
            app.SaveChanges();
        }

        public int Update(T value)
        {
           return app.SaveChanges();
        }
    }
}
