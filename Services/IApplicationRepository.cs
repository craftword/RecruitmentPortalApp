using RecruitmentPortalApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecruitmentPortalApp.Services
{
    public interface IApplicationRepository
    {
        ICollection<ApplicationModel> GetApplication();
        bool CreateApplication(ApplicationModel Application);
        bool UpdateApplication(ApplicationModel Application);
        bool DeleteApplication(ApplicationModel Application);
        ApplicationModel GetApplication(int Id);
        ApplicationModel GetApplicationScoreboard(int Id);
        ApplicationModel GetApplicationResponses(int Id);

        bool ApplicationExists(int Id);
        bool Save();
    }
}
