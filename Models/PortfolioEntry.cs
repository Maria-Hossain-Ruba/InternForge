using System;
using System.ComponentModel.DataAnnotations;

namespace InternForge.Models
{
    public class PortfolioEntry
    {
                        
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public string StudentName { get; set; }
        public string StudentEmail { get; set; }
        public string Description { get; set; }
        public string SkillsGained { get; set; }
        public DateTime DateAdded { get; set; }

        public Project Project { get; set; }
    }
}
