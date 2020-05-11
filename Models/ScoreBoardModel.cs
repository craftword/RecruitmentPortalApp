using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecruitmentPortalApp.Models
{
    public class ScoreBoardModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }        
        public int? StageId { get; set; }
        public int? ApplicationId { get; set; }
        public int Score { get; set; }
        public DateTime Created_at { get; set; }

        [ForeignKey("StageId")]
        public virtual StagesModel Stage { get; set; }

        [ForeignKey("ApplicationId")]
        public virtual ApplicationModel Application { get; set; }
    }
}
