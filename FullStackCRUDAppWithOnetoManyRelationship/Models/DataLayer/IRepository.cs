namespace FullStackCRUDAppWithOnetoManyRelationship.Models.DataLayer
{

    public interface IRepository<T> where T : class
    {
        //list methods with query options/ passing query options while listing things
        IEnumerable<T> List(QueryOptions<T> options);

        //Get by iD
        T? GetById(int id);

        //Get Type By LINQ query
        T? Get(QueryOptions<T> options);

        //create
        void Insert(T entity);

        //update
        void Update(T entity);

        //delete
        void Delete(T entity);

        //save
        void save();



    }
}
