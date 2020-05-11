using RecruitmentPortalApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecruitmentPortalApp.Services
{
    public interface IProfileRepository
    {
        ICollection<ProfileModel> GetProfiles();
        bool CreateProfile(ProfileModel Profile);
        bool UpdateProfile(ProfileModel Profile);
        bool DeleteProfile(ProfileModel Profile);
        ProfileModel GetProfile(int Id);
        bool ProfileExists(int Id);
        bool Save();
    }
}
