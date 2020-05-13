using RecruitmentPortalApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecruitmentPortalApp.Services
{
    public class ProfileRepository : IProfileRepository
    {
        private readonly ApplicationDBContext _ApplicationDBContext;

        public ProfileRepository(ApplicationDBContext applicationDbContext)
        {
            _ApplicationDBContext = applicationDbContext;
        }
        public bool CreateProfile(ProfilesModel Profile)
        {
            _ApplicationDBContext.Add(Profile);

            return Save();
        }

        public bool DeleteProfile(ProfilesModel Profile)
        {
            _ApplicationDBContext.Remove(Profile);
            return Save();
        }

        public ProfilesModel GetProfile(int Id)
        {
            var profile = _ApplicationDBContext.Profiles
              .Where(b => b.Id == Id).FirstOrDefault();
            return profile;
        }

       

        public bool ProfileExists(int Id)
        {
            return _ApplicationDBContext.Profiles.Any(b => b.Id == Id);
        }

        public bool Save()
        {
            var saved = _ApplicationDBContext.SaveChanges();
            return saved >= 0 ? true : false;
        }

        public bool UpdateProfile(ProfilesModel Profile)
        {
            _ApplicationDBContext.Update(Profile);
            return Save();
        }
    }
}
