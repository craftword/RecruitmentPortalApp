using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecruitmentPortalApp.Models
{
    public class ApplicationModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required]
        public string Resume { get; set; }
        public string Status { get; set; }
        public string Reason { get; set; }
        public int JobID { get; set; }
        public DateTime Created_at { get; set; }
    }
}
