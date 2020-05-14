using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecruitmentPortalApp.Models
{
    public class AnswersModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Content { get; set; }
        public bool IsCorrect { get; set; }       
        public int QuestionId { get; set; }
        public DateTime Created_at { get; set; }
        
        public virtual QuestionsModel Question { get; set; }
    }
}
