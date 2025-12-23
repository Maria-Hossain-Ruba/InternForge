using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InternForge.Models
{
    [Table("Projects", Schema = "dbo")]
    public class Project
    {
        [Key]
        public int ProjectID { get; set; }

        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? RequiredSkills { get; set; }
        public DateTime? Deadline { get; set; }
        public string? Status { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string? OrgName { get; set; }
    }
}
