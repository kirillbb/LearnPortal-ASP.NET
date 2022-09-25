namespace basicFunctions_DB.Repository
{
    internal interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();

        T GetById(object id);

        void Insert(T obj);

        void Update(T obj);

        void Delete(object id);

        void Save();
    }
}
