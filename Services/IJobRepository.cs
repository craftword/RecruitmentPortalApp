using RecruitmentPortalApp.Dtos;
using RecruitmentPortalApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecruitmentPortalApp.Services
{
    public interface IJobRepository
    {
        ICollection<JobsModel> GetJobs();
        bool CreateJob(JobsModel Job);
        bool UpdateJob(JobsModel Job);
        bool DeleteJob(JobsModel Job);
        JobsModel GetJob(int jobId);
        JobsModel GetJobApplicants(int jobId);
        StagesModel GetJobStages(int jobId);
        bool JobExists(int jobId);
        bool Save();
    }
}
