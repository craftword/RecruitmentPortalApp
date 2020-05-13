using RecruitmentPortalApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecruitmentPortalApp.Services
{
    public interface IProfileRepository
    {
        
        bool CreateProfile(ProfilesModel Profile);
        bool UpdateProfile(ProfilesModel Profile);
        bool DeleteProfile(ProfilesModel Profile);
        ProfilesModel GetProfile(int Id);
        bool ProfileExists(int Id);
        bool Save();
    }
}
