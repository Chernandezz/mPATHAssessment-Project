using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.ViewModels;
using Data.DAL;
using Model.Models;

namespace Logic.BLL
{
    public class DoctorBLL
    {
        public static PagedListVMR<DoctorVMR> GetAll(int count, int page, string searchText)
        {
            return DoctorDAL.GetAll(count, page, searchText);

        }
        public static DoctorVMR GetById(long id)
        {
            return DoctorDAL.GetById(id);

        }
        public static long Create(Doctor item)
        {
            return DoctorDAL.Create(item);
        }
        public static void Update(DoctorVMR item)
        {
            DoctorDAL.Update(item);
        }
        public static void Delete(List<long> ids)
        {
            DoctorDAL.Delete(ids);
        }
    }
}