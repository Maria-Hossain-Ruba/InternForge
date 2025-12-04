using System;

namespace InternForge.Models
{
    public class Application
    {
        public int ApplicationID { get; set; }
        public int ProjectID { get; set; }
        public string ApplicantName { get; set; }
        public string ApplicantEmail { get; set; }
        public string CoverLetter { get; set; }
        public string Status { get; set; }
        public DateTime AppliedAt { get; set; }

        public Project Project { get; set; }
    }
}
