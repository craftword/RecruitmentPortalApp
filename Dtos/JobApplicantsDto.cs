using RecruitmentPortalApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecruitmentPortalApp.Dtos
{
    public class JobApplicantsDto
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Roles { get; set; }
        public string Category { get; set; }
        public DateTime ClosingDate { get; set; }

        public virtual ICollection<ApplicationsModel> Applications { get; set; }
    }
}
