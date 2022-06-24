namespace CSVImporter.Interfaces
{
    /// <summary>
    /// CSV file upload service
    /// </summary>
    public interface ICsvUploadService
    {
        /// <summary>
        ///  File uploader
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        Task<string> UploadFileAsync(IFormFile file);
    }
}
