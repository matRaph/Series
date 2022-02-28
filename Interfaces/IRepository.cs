using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Series.Interfaces
{
    public interface IRepository<T>
    {
        List<T> List();

        T ReturnByID(int ID);

        void Insert(T entity);

        void Remove(int ID);

        void Update(int ID, T entity);

        int NextID();
    }
}
