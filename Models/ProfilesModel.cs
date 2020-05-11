using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace RecruitmentPortalApp.Models
{
    public class ProfilesModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string HighestEducation { get; set; }
        public string? UserID { get; set; }
        [ForeignKey("UserID")]
        public virtual UserModel User { get; set; }
        public DateTime Created_at { get; set; }
    }
}
