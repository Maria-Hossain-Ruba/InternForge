using System;
using System.ComponentModel.DataAnnotations;

namespace InternForge.Models
{
    public class PortfolioEntry
    {
        [Key]                     // 👈 tell EF this is the primary key
        public int PortfolioID { get; set; }

        public int ProjectID { get; set; }
        public string StudentName { get; set; }
        public string StudentEmail { get; set; }
        public string Description { get; set; }
        public string SkillsGained { get; set; }
        public DateTime DateAdded { get; set; }

        public Project Project { get; set; }
    }
}
