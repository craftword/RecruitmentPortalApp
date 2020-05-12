using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace RecruitmentPortalApp.Models
{
    public class UserModel : IdentityUser
    {
        public virtual ICollection<ProfilesModel> Profiles { get; set; }
        public virtual ICollection<ApplicationsModel> Applications { get; set; }
        public virtual ICollection<StaffDocsModel> StaffDocuments { get; set; }
    }
}
