using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.Interface
{
  public  interface IRepository<T> where T:new()
    {
        bool Create(T obj);

        bool Update(T obj);
    }
}
