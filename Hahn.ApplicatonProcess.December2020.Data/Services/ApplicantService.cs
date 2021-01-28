using Hahn.ApplicatonProcess.December2020.Domain.Interfaces;
using Hahn.ApplicatonProcess.December2020.Domain.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.December2020.Data.Services
{
    internal class ApplicantService : IApplicantService
    {
        private readonly AppDbContext context;
        public ApplicantService(AppDbContext context)
        {
            this.context = context;
        }
        public Task<Applicant> AddApplicant(Applicant applicant)
        {
            throw new NotImplementedException();
        }

        public void DeleteApplicant(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Applicant> GetApplicant(int id) => 
            await context.Applicants.FirstOrDefaultAsync(x => x.Id == id);
    }
}
