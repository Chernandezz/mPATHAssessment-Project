using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.ViewModels
{
    public class PagedListVMR<T>
    {
        public int totalCount { get; set;}
        public IEnumerable<T> element { get; set; }

        public PagedListVMR() 
        {
            element = new List<T>();
            totalCount = 0;
        }
    }
}
