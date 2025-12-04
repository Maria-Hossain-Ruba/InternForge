using System;

namespace InternForge.Models
{
    public class Application
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public string StudentName { get; set; }
        public string StudentEmail { get; set; }
        public string CoverLetter { get; set; }
        public string FileName { get; set; }
        public string Status { get; set; }
        public DateTime AppliedAt { get; set; }

        public Project Project { get; set; }
    }
}
