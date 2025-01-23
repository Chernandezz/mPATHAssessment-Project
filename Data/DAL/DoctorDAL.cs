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
                var query = db.Doctor.Where(x => !x.deleted).Select(x => new DoctorVMR
                {
                    id = x.id,
                    firstName = x.firstName,
                    lastName = x.lastName,
                    email = x.email
                });

                if (!string.IsNullOrEmpty(searchText))
                {
                    query = query.Where(x => x.firstName.Contains(searchText) || x.lastName.Contains(searchText));
                }

                response.totalCount = query.Count();

                response.element = query
                    .OrderBy(x => x.lastName)
                    .Skip(page * count)
                    .Take(count)
                    .ToList();

            }

            return response;
        }
        public static DoctorVMR GetById(long id) 
        {
            DoctorVMR item = null;
            using (var db = DbConnection.Create())
            {
                item = db.Doctor.Where(x => !x.deleted && x.id == id).Select(x => new DoctorVMR
                {
                    id = x.id,
                    firstName = x.firstName,
                    lastName = x.lastName,
                    email = x.email,
                    active = x.active

                }).FirstOrDefault();

            }
            return item;

        }
        public static long Create(Doctor item) {
            long id = 0;
            using (var db = DbConnection.Create())
            {
                item.deleted = false;
                db.Doctor.Add(item);
                db.SaveChanges();

            }
            return id;
        
        }
        public static void Update(DoctorVMR item) {
            using (var db = DbConnection.Create())
            {
                var itemUpdate = db.Doctor.Find(item.id);

                itemUpdate.firstName = item.firstName;
                itemUpdate.lastName = item.lastName;
                itemUpdate.email = item.email;
                itemUpdate.active = item.active;

                db.Entry(itemUpdate).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

            }
        }
        public static void Delete(List<long> ids) {
            using (var db = DbConnection.Create())
            {
                var items = db.Doctor.Where(x => ids.Contains(x.id));

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
