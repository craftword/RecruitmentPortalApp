using RecruitmentPortalApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecruitmentPortalApp.Dtos
{
    public class UserDocsDto
    {
        public string Id { get; set; }      

        public ICollection<StaffDocsModel> StaffDocuments { get; set; }
    }
}
