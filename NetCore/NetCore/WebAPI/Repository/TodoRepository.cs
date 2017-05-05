using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Interface;
using WebAPI.Model;

namespace WebAPI.Repository
{
    public class TodoRepository : ITodoRepository
    {
        public void Add(TodoItem item)
        {
            throw new NotImplementedException();
        }

        public TodoItem Find(long key)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TodoItem> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Remove(long key)
        {
            throw new NotImplementedException();
        }

        public void Update(TodoItem item)
        {
            throw new NotImplementedException();
        }
    }
}
