using System;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecruitmentPortalApp.Models
{
    public class JobStagesModel
    {

        public int Id { get; set; }
        public int? JobId { get; set; }     
        public int? StageId { get; set; }
        [ForeignKey("JobId")]
        public virtual JobsModel Job { get; set; }
        [ForeignKey("StageId")]
        public virtual StagesModel Stage { get; set; }
    }
}
