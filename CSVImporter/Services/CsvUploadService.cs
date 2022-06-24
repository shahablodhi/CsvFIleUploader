using CsvHelper;
using CSVImporter.Controllers;
using CSVImporter.Interfaces;
using System.Globalization;

namespace CSVImporter.Services
{
    /// <summary>
    /// CSV file upload service
    /// </summary>
    public class CsvUploadService : ICsvUploadService
    {
        /// <summary>
        /// File uploader
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public async Task<string> UploadFileAsync(IFormFile file)
        {
            var fileExtension = Path.GetExtension(file.FileName);
            var filename = Guid.NewGuid().ToString() + fileExtension;
            var dir = Path.Combine(Directory.GetCurrentDirectory().Replace("\\bin\\Debug\\net6.0", String.Empty), "files");
            var filepath = Path.Combine(dir, filename);
            Directory.CreateDirectory(dir);
            using (FileStream fs = File.Create(filepath))
            {
                file.CopyTo(fs);
            }
            if (fileExtension == ".csv")
            {
                using (var reader = new StreamReader(filepath))
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    var records = csv.GetRecordsAsync<FileSchema>();
                    await foreach (var record in records)
                    {
                        //Operations here
                        var fn = record.FirstName;

                    }
                }
            }
            return filepath;
        }
    }
}
