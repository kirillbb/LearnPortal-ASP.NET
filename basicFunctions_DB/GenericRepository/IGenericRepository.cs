﻿namespace basicFunctions_DB.GenericRepository
{
    internal interface IGenericRepository<T> where T : class
    {
        IEnumerable<T> GetAll();

        T GetById(object id);

        void Insert(T obj);

        void Update(T obj);

        void Delete(object id);

        void Save();
    }
}
