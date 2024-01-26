using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using workshop.console.Models;

namespace workshop.console.Repository
{
    public interface IRepository<T> where T : class
    {        
        void Add(T entity);
    }
}
