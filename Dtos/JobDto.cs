using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RecruitmentPortalApp.Dtos
{
    public class JobDto
    {
       
        public int Id { get; set; }        
        public string Code { get; set; }        
        public string Title { get; set; }
        public string Description { get; set; }
        public string Roles { get; set; }
        public string Category { get; set; }
        public DateTime ClosingDate { get; set; }
    }
}
