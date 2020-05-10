using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecruitmentPortalApp.Models
{
    public class StagesModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }        
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public int NumberOfQuestions { get; set; }
        public string Duration { get; set; }
        public int TotalScore { get; set; }
        public DateTime Created_at { get; set; }
    }
}
