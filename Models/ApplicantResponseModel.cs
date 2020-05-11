using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecruitmentPortalApp.Models
{
    public class ApplicantResponseModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Content { get; set; }        
        public int? QuestionId { get; set; }
        public int? ApplicationId { get; set; }
        public DateTime Created_at { get; set; }
        [ForeignKey("QuestionId")]
        public virtual QuestionsModel Question { get; set; }
        [ForeignKey("ApplicationId")]
        public virtual ApplicationModel Application { get; set; }
    }
}
