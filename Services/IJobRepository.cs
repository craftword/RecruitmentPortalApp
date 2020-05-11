using RecruitmentPortalApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecruitmentPortalApp.Services
{
    public interface IJobRepository
    {
        ICollection<JobModel> GetJobs();
        bool CreateJob(JobModel Job);
        bool UpdateJob(JobModel Job);
        bool DeleteJob(JobModel Job);
        JobModel GetJob(int jobId);
        JobModel GetJobApplicants(int jobId);
        JobModel GetJobStages(int jobId);
        bool JobExists(int jobId);
        bool Save();
    }
}
