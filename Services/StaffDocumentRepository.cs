using RecruitmentPortalApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecruitmentPortalApp.Services
{
    public class StaffDocumentRepository
    {
        private readonly ApplicationDBContext _ApplicationDBContext;

        public StaffDocumentRepository(ApplicationDBContext applicationDbContext)
        {
            _ApplicationDBContext = applicationDbContext;
        }

        public bool CreateStaffDocs(StaffDocsModel StaffDocs)
        {

            _ApplicationDBContext.Add(StaffDocs);

            return Save();
        }

        public bool DeleteStaffDocs(StaffDocsModel StaffDocs)
        {
            _ApplicationDBContext.Remove(StaffDocs);
            return Save();
        }


        public StaffDocsModel GetStaffDoc(int Id)
        {
            var doc = _ApplicationDBContext.StaffDocuments
                .Where(b => b.Id == Id).FirstOrDefault();
            return doc;
        }

        public ICollection<StaffDocsModel> GetStaffDocs()
        {
            return _ApplicationDBContext.StaffDocuments.OrderBy(b => b.Title).ToList();
        }

        public bool StaffDocExists(int Id)
        {
            return _ApplicationDBContext.StaffDocuments.Any(b => b.Id == Id);
        }

        public bool Save()
        {
            var saved = _ApplicationDBContext.SaveChanges();
            return saved >= 0 ? true : false;
        }

        public bool  UpdateStaffDocs(StaffDocsModel StaffDocs)
        {
            _ApplicationDBContext.Update(StaffDocs);
            return Save();
        }
    }
}
