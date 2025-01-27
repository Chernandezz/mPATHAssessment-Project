using System;
using System.Collections.Generic;
using Common.ViewModels;
using Data.DAL;
using Model.Models;

namespace Logic.BLL
{
    public class DischargeBLL
    {
        public static PagedListVMR<DischargeVMR> GetAll(int count, int page, string searchText)
        {
            return DischargeDAL.GetAll(count, page, searchText);
        }

        public static DischargeVMR GetById(long id)
        {
            return DischargeDAL.GetById(id);
        }

        public static long Create(Discharge item)
        {
            return DischargeDAL.Create(item);
        }

        public static void Update(DischargeVMR item)
        {
            DischargeDAL.Update(item);
        }

        /*
        public static void Delete(List<long> ids)
        {
            DischargeDAL.Delete(ids);
        }
        */
    }
}
