using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.ViewModels;
using Model.Models;

namespace Data.DAL
{
    public class DoctorDAL
    {
        public static PagedListVMR<DoctorVMR> GetAll(int count, int page, string searchText) 
        {
            PagedListVMR<DoctorVMR> response = new PagedListVMR<DoctorVMR> ();

            using( var db = DbConnection.Create())
            {

            }

            return response;
        }
        public static DoctorVMR GetById(long id) 
        {
            DoctorVMR item = null;
            return item;

        }
        public static long Create(Doctor item) {
            long id = 0;
            return id;
        
        }
        public static void Update(DoctorVMR item) {
        
        }
        public static void Delete(List<long> ids) { }
    }
}
