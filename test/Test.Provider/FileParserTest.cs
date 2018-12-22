using Infrastructure.DataConnector.Contracts;
using Moq;
using Provider.Subscription.Logic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Test.Provider
{
    public class FileParserTest
    {
        #region Fields

        private readonly Mock<IFileConnector> _mockFileConnector;
        private readonly FileParser _fileParser;

        #endregion

        #region Initializer

        public FileParserTest()
        {
            _mockFileConnector = new Mock<IFileConnector>();
            var mockConnectorFactory = new Mock<IConnectorFactory>();

            mockConnectorFactory.Setup(c => c.CreateFileConnector()).Returns(_mockFileConnector.Object);

            _fileParser = new FileParser(mockConnectorFactory.Object, 1, It.IsAny<long>());
        }

        #endregion

        #region Tests

        [Fact]
        public async Task Parse_AllParsed_Success()
        {
            #region	Setups

            var fileContent = @"D35000095400000016000000000031.0511-05-20160042016A-561607920
                                D35000095400000016000000000031.0511-05-20160042016A-561607920";

            _mockFileConnector.Setup(c => c.ReadFile(It.IsAny<string>(), It.IsAny<Encoding>(), It.IsAny<long>())).ReturnsAsync(fileContent);

            #endregion

            #region	Acts

            await _fileParser.Parse(It.IsAny<string>());

            #endregion

            #region	Asserts

            Assert.NotNull(_fileParser.ParsedSubscribers);
            Assert.NotNull(_fileParser.UnparsedSubscribers);
            Assert.Equal(2, _fileParser.ParsedSubscribers.Count);
            Assert.Empty(_fileParser.UnparsedSubscribers);

            _mockFileConnector.Verify(c => c.ReadFile(It.IsAny<string>(), It.IsAny<Encoding>(), It.IsAny<long>()), Times.Once);

            #endregion
        }

        [Fact]
        public async Task Parse_SomeParsed_Success()
        {
            #region	Setups

            var fileContent = @"D35000095400000016000000000031.0511-05-20160042016A-561607920
                                D35000095400000016000000000031.0511-05-20160042016A-561607920
                                D35asdasdasdfdsfds-561607920";

            _mockFileConnector.Setup(c => c.ReadFile(It.IsAny<string>(), It.IsAny<Encoding>(), It.IsAny<long>())).ReturnsAsync(fileContent);

            #endregion

            #region	Acts

            await _fileParser.Parse(It.IsAny<string>());

            #endregion

            #region	Asserts

            Assert.NotNull(_fileParser.ParsedSubscribers);
            Assert.NotNull(_fileParser.UnparsedSubscribers);
            Assert.Equal(2, _fileParser.ParsedSubscribers.Count);
            Assert.Single(_fileParser.UnparsedSubscribers);

            _mockFileConnector.Verify(c => c.ReadFile(It.IsAny<string>(), It.IsAny<Encoding>(), It.IsAny<long>()), Times.Once);

            #endregion
        }

        #endregion
    }
}
