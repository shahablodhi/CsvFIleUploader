using CSVImporter.Services;
using Microsoft.AspNetCore.Http;
using Moq;
using System.IO;
using System.Threading.Tasks;
using Xunit;

namespace CSVImporter.UnitTests
{
    /// <summary>
    /// Service Test
    /// </summary>
    public class CsvUploadServiceTest
    {
        private readonly CsvUploadService _sut;

        public CsvUploadServiceTest()
        {
            _sut = new CsvUploadService();
        }
        [Fact]
        public async Task Check_UploadFile_Uploads_Success()
        {
            //Arrange
            var fileMock = new Mock<IFormFile>();
            var content = "Hello World from a Fake File";
            var fileName = "test.csv";
            var ms = new MemoryStream();
            var writer = new StreamWriter(ms);
            writer.Write(content);
            writer.Flush();
            ms.Position = 0;
            fileMock.Setup(_ => _.OpenReadStream()).Returns(ms);
            fileMock.Setup(_ => _.FileName).Returns(fileName);
            fileMock.Setup(_ => _.Length).Returns(ms.Length);
            var file = fileMock.Object;

            //Act
            var path = await _sut.UploadFileAsync(file);

            //deletes the mock file after evaluating
            File.Delete(path);

            //Assert
            Assert.Contains("file", path);
        }
    }
}