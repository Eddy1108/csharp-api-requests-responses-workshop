using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using workshop.console.Models;

namespace workshop.console.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        //DRY
        //DO not REPEAT YOURSELF
        public void Add(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
