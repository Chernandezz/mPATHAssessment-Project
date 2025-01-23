using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.ViewModels;

namespace Data.DAL
{
    public class DoctorDAL
    {
        public static PagedListVMR<DoctorVMR> GetAll(int count, int page, string searchText) 
        {
            PagedListVMR<DoctorVMR> response = new PagedListVMR<DoctorVMR> ();
            return response;
        }
        GetById() { }
        Create() { }
        Update() { }
        Delete() { }
    }
}
