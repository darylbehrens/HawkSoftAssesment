using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HawkSoftAssesment.Models.Interfaces
{
    public abstract class SqlStore<T> : IDataStore<T>
    {
        protected readonly string ConnectionString;

        public SqlStore(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public virtual Task<IEnumerable<T>> GetBy(int i) 
        {
            throw new NotImplementedException(); 
        }

        public virtual Task<int> Insert(T t) 
        { 
            throw new NotImplementedException(); 
        }

        public virtual Task Update(T t) 
        { 
            throw new NotImplementedException(); 
        }

        public virtual Task Delete (int i) 
        {
            throw new NotImplementedException(); 
        }

        public virtual Task<IEnumerable<T>> Get()
        {
            throw new NotImplementedException();
        }
    }
}
