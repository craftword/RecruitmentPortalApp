﻿using RecruitmentPortalApp.Dtos;
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
        bool AddJobStages(int jobId, int stageId);
        JobsModel GetJobApplicants(int jobId);
        List<StagesModel> GetJobStages(int jobId);
        bool JobExists(int jobId);
        bool Save();
    }
}
