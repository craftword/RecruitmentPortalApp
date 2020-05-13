using RecruitmentPortalApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecruitmentPortalApp.Dtos
{
    public class QuestionsDto
    {
        public int Id { get; set; }        
        public string Content { get; set; }
        public string Type { get; set; }
        public int Point { get; set; }
        public string Active { get; set; }      
              

        public virtual ICollection<AnswersModel> Answers { get; set; }
    }
}
