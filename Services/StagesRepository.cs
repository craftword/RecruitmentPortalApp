using Microsoft.EntityFrameworkCore;
using RecruitmentPortalApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecruitmentPortalApp.Services
{
    public class StagesRepository : IStagesRepository
    {

        private readonly ApplicationDBContext _ApplicationDBContext;

        public StagesRepository(ApplicationDBContext applicationDbContext)
        {
            _ApplicationDBContext = applicationDbContext;
        }

        public bool CreateStages(StagesModel Stages)
        {
            _ApplicationDBContext.Add(Stages);

            return Save();
        }

        public bool DeleteStages(StagesModel Stages)
        {
            _ApplicationDBContext.Remove(Stages);
            return Save();
        }

        public StagesModel GetStage(int stageId)
        {
            var stage = _ApplicationDBContext.Stages
              .Where(b => b.Id == stageId).FirstOrDefault();
            return stage;
        }

        public StagesModel GetStageQuestions(int stageId)
        {
            var questions = _ApplicationDBContext.Stages
                .Include(c => c.Questions)                    
                .Where(b => b.Id == stageId).FirstOrDefault();

            return questions;
        }

        public ICollection<StagesModel> GetStages()
        {
            return _ApplicationDBContext.Stages.OrderBy(b => b.Id).ToList();
        }

        public bool Save()
        {
            var saved = _ApplicationDBContext.SaveChanges();
            return saved >= 0 ? true : false;
        }

        public bool StageExists(int stageId)
        {
            return _ApplicationDBContext.Stages.Any(b => b.Id == stageId);
        }

        public bool UpdateStages(StagesModel Stages)
        {
            _ApplicationDBContext.Update(Stages);
            return Save();
        }
    }
}
