using RecruitmentPortalApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecruitmentPortalApp.Services
{
    public class OrganizationDocsRepository : IOrganizationDocsRepository
    {
        private readonly ApplicationDBContext _ApplicationDBContext;

        public OrganizationDocsRepository(ApplicationDBContext applicationDbContext)
        {
            _ApplicationDBContext = applicationDbContext;
        }

        public bool CreateOrganizationDocs(OrganizationDocsModel OrganizationDocs)
        {

            _ApplicationDBContext.Add(OrganizationDocs);

            return Save();
        }

        public bool DeleteOrganizationDocs(OrganizationDocsModel OrganizationDocs)
        {
            _ApplicationDBContext.Remove(OrganizationDocs);
            return Save();
        }
              

        public OrganizationDocsModel GetOrganizationDoc(int Id)
        {
            var doc = _ApplicationDBContext.OrganizationDocuments                
                .Where(b => b.Id == Id).FirstOrDefault();
            return doc;
        }

        public ICollection<OrganizationDocsModel> GetOrganizationDocs()
        {
            return _ApplicationDBContext.OrganizationDocuments.OrderBy(b => b.Title).ToList();
        }

        public bool OrganizationDocExists(int Id)
        {
            return _ApplicationDBContext.OrganizationDocuments.Any(b => b.Id == Id);
        }

        public bool Save()
        {
            var saved = _ApplicationDBContext.SaveChanges();
            return saved >= 0 ? true : false;
        }

        public bool UpdateOrganizationDocs(OrganizationDocsModel OrganizationDocs)
        {
            _ApplicationDBContext.Update(OrganizationDocs);
            return Save();
        }
    }
}
