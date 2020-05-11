using RecruitmentPortalApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecruitmentPortalApp.Services
{
    public interface IApplicationRepository
    {
        ICollection<ApplicationsModel> GetApplication();
        bool CreateApplication(ApplicationsModel Application);
        bool UpdateApplication(ApplicationsModel Application);
        bool DeleteApplication(ApplicationsModel Application);
        ApplicationsModel GetApplication(int Id);
        ApplicationsModel GetApplicationScoreboard(int Id);
        ApplicationsModel GetApplicationResponses(int Id);
        bool AddScoreBoard(ScoreBoardsModel scoreboard);
        bool AddApplicantResponse(ApplicantResponsesModel response);

        bool ApplicationExists(int Id);
        bool Save();
    }
}
