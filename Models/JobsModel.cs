using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace RecruitmentPortalApp.Models
{
    public class JobsModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Code { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        public string JobRoles { get; set; }
        public string Category { get; set; }
        public DateTime ClosingDate { get; set; }
        public virtual ICollection<JobStagesModel> JobStages { get; set; }
        public virtual ICollection<ApplicationsModel> Applications { get; set; }


    }
}
