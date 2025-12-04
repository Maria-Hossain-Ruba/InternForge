using System;

namespace InternForge.Models
{
    public class Certificate
    {
        public int CertificateID { get; set; }
        public int ProjectID { get; set; }
        public string StudentName { get; set; }
        public string StudentEmail { get; set; }
        public string CertificateNumber { get; set; }
        public string FilePath { get; set; }
        public DateTime IssuedAt { get; set; }

        public Project Project { get; set; }
    }
}
