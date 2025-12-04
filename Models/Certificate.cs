using System;

namespace InternForge.Models
{
    public class Certificate
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public string StudentName { get; set; }
        public string StudentEmail { get; set; }
        public string CertificateNumber { get; set; }
        public string FilePath { get; set; }
        public DateTime IssuedAt { get; set; }

        public Project Project { get; set; }
    }
}
