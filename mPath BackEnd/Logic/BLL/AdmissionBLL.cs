using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.ViewModels;
using Data.DAL;

namespace Logic.BLL
{
    public class AdmissionBLL
    {
        public static PagedListVMR<AdmissionVMR> GetAll(int count, int page, string searchText)
        {
            return AdmissionDAL.GetAll(count, page, searchText);

        }
    }
}
