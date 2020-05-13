using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecruitmentPortalApp.Models
{
    public class ScoreBoardsModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }        
        public int? StagesId { get; set; }
        public int? ApplicationsId { get; set; }
        public int Score { get; set; }
        public DateTime Created_at { get; set; }

        [ForeignKey("StagesId")]
        public virtual StagesModel Stage { get; set; }

        [ForeignKey("ApplicationsId")]
        public virtual ApplicationsModel Application { get; set; }
    }
}
