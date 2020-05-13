using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecruitmentPortalApp.Dtos
{
    public class ApplicationsDto
    {
        public int Id { get; set; }       
        public string FullName { get; set; }    
        public string Status { get; set; }
        public string Reason { get; set; }
    }
}
