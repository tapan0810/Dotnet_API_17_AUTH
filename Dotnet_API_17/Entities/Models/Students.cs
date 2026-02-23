namespace Dotnet_API_17.Entities.Models
{
    public class Students
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public DateTime EnrollmentDate { get; set; }= DateTime.Now;
    }
}
