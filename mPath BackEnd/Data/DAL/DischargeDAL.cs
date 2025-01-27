using System;
using System.Collections.Generic;
using System.Linq;
using Common.ViewModels;
using Model.Models;

namespace Data.DAL
{
    public class DischargeDAL
    {
        public static PagedListVMR<DischargeVMR> GetAll(int count, int page, string searchText)
        {
            PagedListVMR<DischargeVMR> response = new PagedListVMR<DischargeVMR>();

            using (var db = DbConnection.Create())
            {
                var query = db.Discharge
                    .Where(x => !x.isDeleted)
                    .Join(
                        db.Admission,
                        discharge => discharge.admissionId,
                        admission => admission.id,
                        (discharge, admission) => new DischargeVMR
                        {
                            id = discharge.id,
                            dischargeDate = discharge.dischargeDate,
                            treatment = discharge.treatment,
                            amount = discharge.amount,
                            doctorId = discharge.doctorId,
                            admissionId = discharge.admissionId,
                            patientName = db.Patient
                                .Where(p => p.id == admission.patientId)
                                .Select(p => p.firstName + " " + p.lastName)
                                .FirstOrDefault(),
                            doctorName = db.Doctor
                                .Where(d => d.id == discharge.doctorId)
                                .Select(d => d.firstName + " " + d.lastName)
                                .FirstOrDefault()
                        });

                if (!string.IsNullOrEmpty(searchText))
                {
                    if (long.TryParse(searchText, out long searchId))
                    {
                        query = query.Where(x => x.id == searchId);
                    }
                    else
                    {
                        query = query.Where(x => x.treatment.Contains(searchText) ||
                                                 x.patientName.Contains(searchText) ||
                                                 x.doctorName.Contains(searchText));
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

        public static DischargeVMR GetById(long id)
        {
            DischargeVMR item = null;

            using (var db = DbConnection.Create())
            {
                item = db.Discharge
                    .Where(x => !x.isDeleted && x.id == id)
                    .Join(
                        db.Admission,
                        discharge => discharge.admissionId,
                        admission => admission.id,
                        (discharge, admission) => new DischargeVMR
                        {
                            id = discharge.id,
                            dischargeDate = discharge.dischargeDate,
                            treatment = discharge.treatment,
                            amount = discharge.amount,
                            doctorId = discharge.doctorId,
                            admissionId = discharge.admissionId,
                            patientName = db.Patient
                                .Where(p => p.id == admission.patientId)
                                .Select(p => p.firstName + " " + p.lastName)
                                .FirstOrDefault(),
                            doctorName = db.Doctor
                                .Where(d => d.id == discharge.doctorId)
                                .Select(d => d.firstName + " " + d.lastName)
                                .FirstOrDefault()
                        })
                    .FirstOrDefault();
            }

            return item;
        }

        public static long Create(Discharge item)
        {
            using (var db = DbConnection.Create())
            {
                db.Discharge.Add(item);
                db.SaveChanges();
            }

            return item.id;
        }

        public static void Update(DischargeVMR item)
        {
            using (var db = DbConnection.Create())
            {
                var itemUpdate = db.Discharge.Find(item.id);

                itemUpdate.dischargeDate = item.dischargeDate;
                itemUpdate.treatment = item.treatment;
                itemUpdate.amount = item.amount;
                itemUpdate.doctorId = item.doctorId;
                itemUpdate.admissionId = item.admissionId;

                db.Entry(itemUpdate).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

        /*
        public static void Delete(List<long> ids)
        {
            using (var db = DbConnection.Create())
            {
                var items = db.Discharge.Where(x => ids.Contains(x.id));

                foreach (var item in items)
                {
                    item.isDeleted = true;
                    db.Entry(item).State = System.Data.Entity.EntityState.Modified;
                }

                db.SaveChanges();
            }
        }
        */
    }
}
