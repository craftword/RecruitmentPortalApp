using RecruitmentPortalApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecruitmentPortalApp.Services
{
    public interface IStagesRepository
    {
        ICollection<StagesModel> GetStages();
        bool CreateStages(StagesModel Stages);
        bool UpdateStages(StagesModel Stages);
        bool DeleteStages(StagesModel Stages);
        StagesModel GetStage(int stageId);
        StagesModel GetStageQuestions(int stageId);
        bool StageExists(int stageId);
        bool Save();
    }
}
