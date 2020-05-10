using System;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecruitmentPortalApp.Models
{
    public class JobStagesModel
    {
        [Key]
        public int JobId { get; set; }
        [Key]
        public int StageId { get; set; }      
        
        public virtual JobModel Job { get; set; }        
        public virtual StagesModel Stage { get; set; }
    }
}
