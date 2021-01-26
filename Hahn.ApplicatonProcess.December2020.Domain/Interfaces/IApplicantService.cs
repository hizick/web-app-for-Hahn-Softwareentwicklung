using Hahn.ApplicatonProcess.December2020.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.December2020.Domain.Interfaces
{
    public interface IApplicantService
    {
        Task<Applicant> GetApplicant(int id);

        Task<Applicant> AddApplicant(Applicant applicant);

        void DeleteApplicant(int id);
    }
}
