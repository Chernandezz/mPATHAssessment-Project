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
    public class PatientBLL
    {
        public static PagedListVMR<PatientVMR> GetAll(int count, int page, string searchText)
        {
            return PatientDAL.GetAll(count, page, searchText);

        }
        public static PatientVMR GetById(long id)
        {
            return PatientDAL.GetById(id);

        }
        public static long Create(Patient item)
        {
            return PatientDAL.Create(item);
        }
        public static void Update(PatientVMR item)
        {
            PatientDAL.Update(item);
        }
        public static void Delete(List<long> ids)
        {
            PatientDAL.Delete(ids);
        }
    }
}
