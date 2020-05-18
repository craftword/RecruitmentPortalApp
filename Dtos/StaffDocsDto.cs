using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecruitmentPortalApp.Dtos
{
    public class StaffDocsDto
    {
        public int Id { get; set; }       
        public string Title { get; set; }        
        public string Url { get; set; }
        public DateTime Created_at { get; set; }
    }
}
