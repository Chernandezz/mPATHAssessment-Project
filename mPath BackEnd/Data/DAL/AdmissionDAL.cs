using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.ViewModels;
using Model.Models;

namespace Data.DAL
{
    public class AdmissionDAL
    {
        public static PagedListVMR<AdmissionVMR> GetAll(int count, int page, string searchText)
        {
            PagedListVMR<AdmissionVMR> response = new PagedListVMR<AdmissionVMR>();

            using (var db = DbConnection.Create())
            {
                var query = db.Admission
                    .Where(x => !x.isDeleted)
                    .Join(
                        db.Patient,
                        admission => admission.patientId, 
                        patient => patient.id,
                        (admission, patient) => new AdmissionVMR
                        {
                            id = admission.id,
                            admissionDate = admission.admissionDate,
                            diagnosis = admission.diagnosis,
                            observation = admission.observation,
                            doctorId = admission.doctorId,
                            patientId = admission.patientId,
                            patientName = patient.firstName + " " + patient.lastName
                        });

                if (!string.IsNullOrEmpty(searchText))
                {
                    if (long.TryParse(searchText, out long searchId))
                    {
                        query = query.Where(x => x.id == searchId);
                    }
                    else
                    {
                        query = query.Where(x => x.diagnosis.Contains(searchText) ||
                                                 x.observation.Contains(searchText) ||
                                                 x.patientName.Contains(searchText)); 
                    }
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

        public static AdmissionVMR GetById(long id)
        {
            AdmissionVMR item = null;
            using (var db = DbConnection.Create())
            {
                var query = db.Admission
                   .Where(x => !x.isDeleted && x.id == id)
                   .Join(
                       db.Patient,
                       admission => admission.patientId,
                       patient => patient.id,
                       (admission, patient) => new AdmissionVMR
                       {
                           id = admission.id,
                           admissionDate = admission.admissionDate,
                           diagnosis = admission.diagnosis,
                           observation = admission.observation,
                           doctorId = admission.doctorId,
                           patientId = admission.patientId,
                           patientName = patient.firstName + " " + patient.lastName
                       }).FirstOrDefault();

            }
            return item;

        }
        public static long Create(Admission item)
        {
            using (var db = DbConnection.Create())
            {
                db.Admission.Add(item);
                db.SaveChanges();

            }
            return item.id;

        }
        public static void Update(AdmissionVMR item)
        {
            using (var db = DbConnection.Create())
            {
                var itemUpdate = db.Admission.Find(item.id);

                itemUpdate.admissionDate = item.admissionDate;
                itemUpdate.diagnosis = item.diagnosis;
                itemUpdate.observation = item.observation;
                itemUpdate.doctorId = item.doctorId;
                itemUpdate.patientId = item.patientId;


                db.Entry(itemUpdate).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

            }
        }
        /*
        public static void Delete(List<long> ids)
        {
            using (var db = DbConnection.Create())
            {
                var items = db.Admission.Where(x => ids.Contains(x.id));

                foreach (var item in items)
                {
                    db.Entry(item).State = System.Data.Entity.EntityState.Modified;
                }
                db.SaveChanges();
            }
        }*/

    }
}
