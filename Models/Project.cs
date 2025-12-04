using System;
using System.Collections.Generic;
using static System.Net.Mime.MediaTypeNames;

namespace InternForge.Models
{
    public class Project
    {
        public int ProjectID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string RequiredSkills { get; set; }
        public DateTime? Deadline { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public string OrgName { get; set; }

        public ICollection<Application> Applications { get; set; }
        public ICollection<PortfolioEntry> PortfolioEntries { get; set; }
        public ICollection<Certificate> Certificates { get; set; }
    }
}
