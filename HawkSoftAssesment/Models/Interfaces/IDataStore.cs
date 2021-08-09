using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HawkSoftAssesment.Models.Interfaces
{
    public interface IDataStore<T>
    {
        public Task<IEnumerable<T>> Get();
        public Task<IEnumerable<T>> GetBy(int i);
        public Task<int> Insert(T t);
        public Task Update(T t);
        public Task Delete(int i);
    }
}
