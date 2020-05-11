using RecruitmentPortalApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecruitmentPortalApp.Services
{
    public interface IQuestionsRepository
    {
        ICollection<QuestionsModel> GetQuestions();
        bool CreateQuestions(QuestionsModel Questions);
        bool UpdateQuestions(QuestionsModel Questions);
        bool DeleteQuestions(QuestionsModel Questions);
        QuestionsModel GetQuestions(int Id);        

        bool CreateQuestionAnswer(AnswersModel Answer);
        bool UpdateQuestionAnswer(AnswersModel Answer);
        bool DeleteQuestionAnswer(AnswersModel Answer);
        bool QuestionsExists(int Id);
        bool Save();
    }
}
