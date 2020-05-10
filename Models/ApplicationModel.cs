using System;
using System.Collections.Generic;
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
        public int? JobID { get; set; }
        [ForeignKey("JobID")]
        public virtual JobModel Job { get; set; }
        public DateTime Created_at { get; set; }

        public virtual ICollection<ScoreBoardModel> ScoreBoards { get; set; }
        public virtual ICollection<ApplicantResponseModel> ApplicationResponses { get; set; }
    }
}
