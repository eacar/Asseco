using Core.Model.Exceptions;
using Infrastructure.DataConnector.Connectors;
using System;
using System.Collections.Generic;
using System.IO.Abstractions.TestingHelpers;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Test.Infrastructure.DataConnector
{
    public class FileConnectorTest : TestBase
    {
        #region Fields

        private readonly MockFile _mockFileTxt;

        #endregion

        #region Initlizer

        public FileConnectorTest()
        {
            _mockFileTxt = new MockFile
            {
                FilePath = @"c:\source.txt",
                FileContent = @"Some testing text"
            };
        }

        #endregion

        #region Tests

        [Fact]
        public async Task ReadFile_Success()
        {
            #region Setups

            var mockFileSystem = new MockFileSystem(new Dictionary<string, MockFileData>
            {
                { _mockFileTxt.FilePath, new MockFileData(_mockFileTxt.FileContent) }
            });
            var fileConnector = new FileConnector(mockFileSystem);

            #endregion

            #region Acts

            var result = await fileConnector.ReadFile(_mockFileTxt.FilePath, Encoding.UTF8, _mockFileTxt.FileContent.Length);

            #endregion

            #region Asserts

            Assert.NotNull(result);
            Assert.Equal(_mockFileTxt.FileContent, result);

            #endregion
        }
        [Fact]
        public async Task ReadFile_Exception_SizeExceeded()
        {
            #region Setups

            long maxFileSizeInBtyes = 1;
            var mockFileSystem = new MockFileSystem(new Dictionary<string, MockFileData>
            {
                { _mockFileTxt.FilePath, new MockFileData(_mockFileTxt.FileContent) }
            });
            var fileConnector = new FileConnector(mockFileSystem);

            #endregion

            #region Acts

            async Task Act()
            {
                await fileConnector.ReadFile(_mockFileTxt.FilePath, Encoding.UTF8, maxFileSizeInBtyes);
            }

            #endregion

            #region Asserts

            try
            {
                await Task.Run(Act);
            }
            catch (Exception ex)
            {
                Assert.IsType<FileException>(ex);
                Assert.Equal($"Current file's size is {_mockFileTxt.FileContent.Length} bytes but cannot be more than {maxFileSizeInBtyes} bytes", ex.Message);
            }
            
            #endregion
        }
        #endregion
    }

    internal class MockFile
    {
        public string FilePath { get; set; }
        public string FileContent { get; set; }
    }
}