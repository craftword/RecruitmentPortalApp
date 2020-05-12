using RecruitmentPortalApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecruitmentPortalApp.Dtos
{
    public class UserDto
    {
        public string Id { get; set; }        
        public string Email { get; set; }
        public string PhoneNumber { get; set; }   

        public ICollection<ProfilesModel> Profile { get; set; }
    }
}
