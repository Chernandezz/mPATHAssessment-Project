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
    public class AdmissionBLL
    {
        public static PagedListVMR<AdmissionVMR> GetAll(int count, int page, string searchText)
        {
            return AdmissionDAL.GetAll(count, page, searchText);

        }
        public static AdmissionVMR GetById(long id)
        {
            return AdmissionDAL.GetById(id);

        }
        public static long Create(Admission item)
        {
            return AdmissionDAL.Create(item);
        }
        public static void Update(AdmissionVMR item)
        {
            AdmissionDAL.Update(item);
        }/*
        public static void Delete(List<long> ids)
        {
            AdmissionDAL.Delete(ids);
        }*/
    }
}
