using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.ViewModels;
using Model.Models;

namespace Data.DAL
{
    public class PatientDAL
    {
        public static PagedListVMR<PatientVMR> GetAll(int count, int page, string searchText)
        {
            PagedListVMR<PatientVMR> response = new PagedListVMR<PatientVMR>();

            using (var db = DbConnection.Create())
            {
                var query = db.Patient.Where(x => !x.deleted).Select(x => new PatientVMR
                {
                    id = x.id,
                    firstName = x.firstName,
                    lastName = x.lastName,
                    address = x.address,
                    phoneNumber = x.phoneNumber,
                    email = x.email,
                    observations = x.observations,

                });

                if (!string.IsNullOrEmpty(searchText))
                {
                    query = query.Where(x => x.firstName.Contains(searchText) || x.lastName.Contains(searchText));
                }

                response.totalCount = query.Count();

                response.element = query
                    .OrderBy(x => x.id)
                    .Skip(page * count)
                    .Take(count)
                    .ToList();

            }

            return response;
        }
        public static PatientVMR GetById(long id)
        {
            PatientVMR item = null;
            using (var db = DbConnection.Create())
            {
                item = db.Patient.Where(x => !x.deleted && x.id == id).Select(x => new PatientVMR
                {
                    id = x.id,
                    firstName = x.firstName,
                    lastName = x.lastName,
                    address = x.address,
                    phoneNumber = x.phoneNumber,
                    email = x.email,
                    observations = x.observations,

                }).FirstOrDefault();

            }
            return item;

        }
        public static long Create(Patient item)
        {
            using (var db = DbConnection.Create())
            {
                item.deleted = false;
                db.Patient.Add(item);
                db.SaveChanges();

            }
            return item.id;

        }
        public static void Update(PatientVMR item)
        {
            using (var db = DbConnection.Create())
            {
                var itemUpdate = db.Patient.Find(item.id);

                itemUpdate.firstName = item.firstName;
                itemUpdate.lastName = item.lastName;
                itemUpdate.address = item.address;
                itemUpdate.phoneNumber = item.phoneNumber;
                itemUpdate.email = item.email;
                itemUpdate.observations = item.observations;


                db.Entry(itemUpdate).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

            }
        }
        public static void Delete(List<long> ids)
        {
            using (var db = DbConnection.Create())
            {
                var items = db.Patient.Where(x => ids.Contains(x.id));

                foreach (var item in items)
                {
                    item.deleted = true;
                    db.Entry(item).State = System.Data.Entity.EntityState.Modified;
                }
                db.SaveChanges();
            }
        }
    }
}
