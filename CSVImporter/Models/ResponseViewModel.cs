namespace CSVImporter.Controllers
{
    public class ResponseViewModel
    {
        public bool Status { get; internal set; }
        public string? Message { get; internal set; }
        public string? StatusCode { get; internal set; }
    }
}