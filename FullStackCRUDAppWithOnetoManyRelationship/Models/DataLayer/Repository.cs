using Microsoft.EntityFrameworkCore;

namespace FullStackCRUDAppWithOnetoManyRelationship.Models.DataLayer
{
    public class Repository<T> : IRepository<T> where T : class //enforce T to be c# class
    {
        //Add references to context
        public ScheduleDBContext context { get; set; }

        //add Generics Table
        DbSet<T> dbSet { get; set; }

        public Repository(ScheduleDBContext ctx)
        {
            context = ctx;

            //set table to any type Pass into generics table
            dbSet = context.Set<T>();
        }

        /// Delete
        public void Delete(T entity) => dbSet.Remove(entity);

        public T? GetById(int id) => dbSet.Find(id);

        /// Get all entities
        public T? Get(QueryOptions<T> options)
        {
            IQueryable<T> query = dbSet;
            foreach (string include in options.GetIncludes())
            {
                query = query.Include(include);
            }
            if (options.HasWhere)
                query = query.Where(options.Where);
            return query.FirstOrDefault();
        }


        /// Create Methods
        public void Insert(T entity) => dbSet.Add(entity);


        /// List Methods
        public IEnumerable<T> List(QueryOptions<T> options)
        {
            //query the Table (dbSet) or any set types
            IQueryable<T> query = dbSet;

            foreach (string include in options.GetIncludes())
            {
                //include is for sub types (teachers and classes)
                query = query.Include(include);  // eager loading
            }

            //Boolean properties in query options class

            if (options.HasWhere)//update the where clause
                query = query.Where(options.Where);
            if (options.HasOrderBy)//sorting in query options class
            {
                if (options.HasThenOrderBy)
                {
                    //implement then by clause
                    query = query.OrderBy(options.OrderBy).ThenBy(options.ThenOrderBy);
                }
                else
                {
                    //implement by clause
                    query = query.OrderBy(options.OrderBy);
                }
            }
            return query.ToList();
        }

        /// save changes
        public void save() => context.SaveChanges();


        /// update
        public void Update(T entity) => dbSet.Update(entity);





    }
}
