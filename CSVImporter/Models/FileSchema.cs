using CsvHelper.Configuration.Attributes;

namespace CSVImporter.Controllers
{
    public class FileSchema
    {
        [Name("Emp ID")]
        public string? EmpId { get; set; }

        [Name("First Name")]
        public string? FirstName { get; set; }

        [Name("Last Name")]
        public string? LastName { get; set; }

        [Name("Date of Birth")]
        public string? DateOfBirth { get; set; }
    }

}