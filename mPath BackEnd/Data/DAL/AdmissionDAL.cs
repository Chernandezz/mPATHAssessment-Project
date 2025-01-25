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

    }
}
