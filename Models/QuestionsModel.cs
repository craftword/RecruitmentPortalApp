using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecruitmentPortalApp.Models
{
    public class QuestionsModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Content { get; set; }
        public string Type { get; set; }
        public int Point { get; set; }
        public string Active { get; set; }
        public int? StageId { get; set; }
        public DateTime Created_at { get; set; }

        [ForeignKey("StageId")]
        public virtual StagesModel Stage { get; set; }

        public virtual ICollection<AnswersModel> Answers { get; set; }
    }
}
