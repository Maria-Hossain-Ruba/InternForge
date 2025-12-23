namespace InternForge.Models;

public class Application
{
    public int ApplicationID { get; set; }

    public int ProjectID { get; set; }

    public string ApplicantName { get; set; } = "";

    public string ApplicantEmail { get; set; } = "";

    public string? CoverLetter { get; set; }   // nullable is OK

    public string Status { get; set; } = "Pending";

    public DateTime? AppliedAt { get; set; }

}
