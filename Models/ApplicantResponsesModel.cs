using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecruitmentPortalApp.Models
{
    public class ApplicantResponsesModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Content { get; set; }        
        public int? QuestionsId { get; set; }
        public int? ApplicationsId { get; set; }
        public DateTime Created_at { get; set; }
        [ForeignKey("QuestionsId")]
        public virtual QuestionsModel Question { get; set; }
        [ForeignKey("ApplicationsId")]
        public virtual ApplicationsModel Application { get; set; }
    }
}
