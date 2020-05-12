using RecruitmentPortalApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecruitmentPortalApp.Services
{
    public interface IOrganizationDocsRepository
    {
        ICollection<OrganizationDocsModel> GetOrganizationDocs();
        bool CreateOrganizationDocs(OrganizationDocsModel OrganizationDocs);
        bool UpdateOrganizationDocs(OrganizationDocsModel OrganizationDocs);
        bool DeleteOrganizationDocs(OrganizationDocsModel OrganizationDocs);
        OrganizationDocsModel GetOrganizationDoc(int Id);
        bool OrganizationDocExists(int Id);
        bool Save();
    }
}
