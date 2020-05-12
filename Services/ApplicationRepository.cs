using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.EntityFrameworkCore;
using RecruitmentPortalApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecruitmentPortalApp.Services
{
    public class ApplicationRepository : IApplicationRepository
    {
        private readonly ApplicationDBContext _ApplicationDBContext;

        public ApplicationRepository (ApplicationDBContext applicationDbContext)
        {
            _ApplicationDBContext = applicationDbContext;
        }

        public bool CreateApplication(ApplicationsModel Application)
        {

            _ApplicationDBContext.Add(Application);

            return Save();
        }

        public bool DeleteApplication(ApplicationsModel Application)
        {
            _ApplicationDBContext.Remove(Application);
            return Save();
        }


        public ApplicationsModel GetApplication(int Id)
        {
            var app = _ApplicationDBContext.Applications                
               .Where(b => b.Id == Id).FirstOrDefault();
            return app;
        }

        public ICollection<ApplicationsModel> GetApplication()
        {
            return _ApplicationDBContext.Applications.OrderBy(b => b.Id).ToList();
        }

        public bool ApplicationExists(int Id)
        {
            return _ApplicationDBContext.Applications.Any(b => b.Id == Id);
        }

        public bool Save()
        {
            var saved = _ApplicationDBContext.SaveChanges();
            return saved >= 0 ? true : false;
        }

        public bool UpdateApplication(ApplicationsModel Application)
        {
            _ApplicationDBContext.Update(Application);
            return Save();
        }

        public ApplicationsModel GetApplicationScoreboard(int Id)
        {
            var app = _ApplicationDBContext.Applications
                .Include(c => c.ScoreBoards)
                .Where(b => b.Id == Id).FirstOrDefault();

            return app;
        }
        public ApplicationsModel GetApplicationResponses(int Id)
        {
            var app = _ApplicationDBContext.Applications
                .Include(c => c.ApplicationResponses)
                .Where(b => b.Id == Id).FirstOrDefault();

            return app;
        }
        public bool AddScoreBoard(ScoreBoardsModel scoreboard)
        {
            _ApplicationDBContext.Add(scoreboard);

            return Save();
        }
        public bool AddApplicantResponse(ApplicantResponsesModel response)
        {
            _ApplicationDBContext.Add(response);

            return Save();
        }

    }
}
