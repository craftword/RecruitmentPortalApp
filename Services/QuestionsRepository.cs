using Microsoft.EntityFrameworkCore;
using RecruitmentPortalApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecruitmentPortalApp.Services
{
    public class QuestionsRepository : IQuestionsRepository
    {

        private readonly ApplicationDBContext _ApplicationDBContext;

        public QuestionsRepository(ApplicationDBContext applicationDbContext)
        {
            _ApplicationDBContext = applicationDbContext;
        }
        public bool CreateQuestionAnswer(AnswersModel Answer)
        {
            _ApplicationDBContext.Add(Answer);

            return Save();
        }

        public bool CreateQuestions(QuestionsModel Questions)
        {
            _ApplicationDBContext.Add(Questions);

            return Save();
        }

        public bool DeleteQuestionAnswer(AnswersModel Answer)
        {
            _ApplicationDBContext.Remove(Answer);
            return Save();
        }

        public bool DeleteQuestions(QuestionsModel Questions)
        {
            _ApplicationDBContext.Remove(Questions);
            return Save();
        }

        public ICollection<QuestionsModel> GetQuestions()
        {
            return _ApplicationDBContext.Questions.OrderBy(b => b.Id).ToList();
        }

        public QuestionsModel GetQuestions(int Id)
        {
            var question = _ApplicationDBContext.Questions
              .Include(c => c.Answers)
              .Where(b => b.Id == Id).FirstOrDefault();

            return question;
        }

       

        public bool QuestionsExists(int Id)
        {
            return _ApplicationDBContext.Questions.Any(b => b.Id == Id);
        }

        public bool Save()
        {
            var saved = _ApplicationDBContext.SaveChanges();
            return saved >= 0 ? true : false;
        }

        public bool UpdateQuestionAnswer(AnswersModel Answer)
        {
            _ApplicationDBContext.Update(Answer);
            return Save();
        }

        public bool UpdateQuestions(QuestionsModel Questions)
        {
            _ApplicationDBContext.Update(Questions);
            return Save();
        }
    }
}
