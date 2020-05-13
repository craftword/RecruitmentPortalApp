using RecruitmentPortalApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecruitmentPortalApp.Services
{
    public interface IStaffDocsRepository
    {
        ICollection<StaffDocsModel> GetStaffDocs();
        bool CreateStaffDocs(StaffDocsModel StaffDocs);
        bool UpdateStaffDocs(StaffDocsModel StaffDocs);
        bool DeleteStaffDocs(StaffDocsModel StaffDocs);
        StaffDocsModel GetStaffDoc(int Id);
        bool StaffDocExists(int Id);
        bool Save();
    }
}
