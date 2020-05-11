using Microsoft.EntityFrameworkCore;
using RecruitmentPortalApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecruitmentPortalApp.Services
{
    public class JobRepository : IJobRepository
    {
        private readonly ApplicationDBContext _ApplicationDBContext;

        public JobRepository(ApplicationDBContext applicationDbContext)
        {
            _ApplicationDBContext = applicationDbContext;
        }
        public bool CreateJob(JobsModel Job)
        {
            _ApplicationDBContext.Add(Job);

            return Save();
        }

        public bool DeleteJob(JobsModel Job)
        {
            _ApplicationDBContext.Remove(Job);
            return Save();
        }

        public JobsModel GetJob(int jobId)
        {
            var job = _ApplicationDBContext.Jobs
               .Where(b => b.Id == jobId).FirstOrDefault();
            return job;
        }

        public JobsModel GetJobApplicants(int jobId)
        {
            var app = _ApplicationDBContext.Jobs
               .Include(c => c.Applications)
               .Where(b => b.Id == jobId).FirstOrDefault();

            return app;
        }

        public ICollection<JobsModel> GetJobs()
        {
            return _ApplicationDBContext.Jobs.OrderBy(b => b.ClosingDate).ToList();
        }

        public StagesModel GetJobStages(int jobId)
        {
            var stages = _ApplicationDBContext.Jobs
                     .Where(m => m.Id == jobId)
                     .SelectMany(m => m.JobStages.Select(mc => mc.Stage)).FirstOrDefault();

            return stages;
        }

        public bool JobExists(int jobId)
        {
            return _ApplicationDBContext.Jobs.Any(b => b.Id == jobId);
        }

        public bool Save()
        {
            var saved = _ApplicationDBContext.SaveChanges();
            return saved >= 0 ? true : false;
        }

        public bool UpdateJob(JobsModel Job)
        {
            _ApplicationDBContext.Update(Job);
            return Save();
        }
    }
}
