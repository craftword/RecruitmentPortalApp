using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecruitmentPortalApp.Models
{
    public class JobStagesModel    {
               
        public int? JobsId { get; set; }
        public virtual JobsModel Job { get; set; }
        public int? StagesId { get; set; }                    
        public virtual StagesModel Stage { get; set; }
    }
}
