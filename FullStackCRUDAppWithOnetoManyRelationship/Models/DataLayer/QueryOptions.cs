using System.Linq.Expressions;

namespace FullStackCRUDAppWithOnetoManyRelationship.Models.DataLayer
{
    public class QueryOptions<T>
    {
        //LINQ Public properties for sorting and filtering
        public Expression<Func<T, Object>> OrderBy { get; set; } = null!;
        public Expression<Func<T, Object>> ThenOrderBy { get; set; } = null!;
        public Expression<Func<T, bool>> Where { get; set; } = null!;


        //private string array for include statements 
        private string[] includes = Array.Empty<string>();

        //public write only properties for include statements - convert string to Array

        public string Includes
        {
            set => includes = value.Replace(" ", "").Split(',');
        }


        //public get method for include statements - returns private string Array
        public string[] GetIncludes() => includes;


        // readonly properties for LINQ queries whether LINQ queries has those or not.
        public bool HasWhere => Where != null;
        public bool HasOrderBy => OrderBy != null;
        public bool HasThenOrderBy => ThenOrderBy != null;


    }
}
