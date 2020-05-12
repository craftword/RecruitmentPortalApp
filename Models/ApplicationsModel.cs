using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecruitmentPortalApp.Models
{
    public class ApplicationsModel
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
        public virtual JobsModel Job { get; set; }
        public string? UserID { get; set; }
        [ForeignKey("UserID")]
        public virtual UserModel User { get; set; }
        public DateTime Created_at { get; set; }

        public virtual ICollection<ScoreBoardsModel> ScoreBoards { get; set; }
        public virtual ICollection<ApplicantResponsesModel> ApplicationResponses { get; set; }
    }
}
