using Core.Util.Extensions;
using Infrastructure.DataConnector.Contracts;
using Provider.Subscription.Contracts;
using Provider.Subscription.Entities;
using System;
using System.Collections.Concurrent;
using System.Text;
using System.Threading.Tasks;
using Core.Model.Exceptions;

namespace Provider.Subscription.Logic
{
    public class FileParser : IFileParser
    {
        #region Fields

        private readonly IConnectorFactory _connectorFactory;
        private readonly int _threadCount;
        private readonly long _maxFileSizeInBtyes;
        private readonly Encoding _encoding;

        #endregion

        #region Properties - IFileParser

        public ConcurrentBag<Subscriber> ParsedSubscribers { get; private set; }
        public ConcurrentBag<SubscriberOriginal> UnparsedSubscribers { get; private set; }

        #endregion

        #region Constructors

        public FileParser(IConnectorFactory connectorFactory, int threadCount, long maxFileSizeInBtyes)
        {
            _connectorFactory = connectorFactory;
            _threadCount = threadCount;
            _maxFileSizeInBtyes = maxFileSizeInBtyes;
            _encoding = Encoding.UTF8;
        }

        #endregion

        #region Methods - Public - IFileParser

        public Task Parse(string filePath)
        {
            return Parse(filePath, _threadCount);
        }

        /// <summary>
        /// Parses the file at given file path with concurrent processors.
        /// Thread count can be increased to have better performence.
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="threadCount"></param>
        /// <returns></returns>
        public async Task Parse(string filePath, int threadCount)
        {
            using (var connector = _connectorFactory.CreateFileConnector())
            {
                try
                {
                    #region Initilizing the concurrent bags

                    ParsedSubscribers = new ConcurrentBag<Subscriber>();
                    UnparsedSubscribers = new ConcurrentBag<SubscriberOriginal>();

                    #endregion

                    #region Reading the File and Splitting lines

                    //Reading the file and spliting every line
                    var fileContent = await connector.ReadFile(filePath, _encoding, _maxFileSizeInBtyes);
                    //This is an assumption that the correct form of a content is always spacefree
                    fileContent = fileContent.Trim().Replace(" ", "");
                    string[] stringSeparators = {"\r\n"};
                    var lines = fileContent.Split(stringSeparators, StringSplitOptions.None);

                    #endregion

                    #region Running Parsers Concurrently

                    await lines.ForEachAsyncConcurrent(
                        async c =>
                        {
                            var subscriber = ParseLine(c);
                            if (subscriber.Item1.IsValid())
                            {
                                ParsedSubscribers.Add(subscriber.Item1);
                            }
                            else
                            {
                                UnparsedSubscribers.Add(subscriber.Item2);
                            }

                        }, threadCount);

                    #endregion
                }
                catch (ConnectorException ex) //We only know this exception is possible. Others should go through.
                {
                    throw new ProviderException($"Filepath {filePath} couldn't be read within provider!", ex);
                }
            }
        }

        #endregion

        #region Methods - Private

        private Tuple<Subscriber, SubscriberOriginal> ParseLine(string line)
        {
            var subscriberNo = ParseLine<string>(line, 1, 9);
            var debt = ParseLine<decimal>(line, 18, 15);
            var dueDate = ParseLine<DateTime>(line, 33, 10);
            var year = ParseLine<int>(line, 46, 4);
            var invoiceNumber = ParseLine<string>(line, 50, 11);

            return Tuple.Create(new Subscriber
                {
                    SubscriberNo = subscriberNo.Item1,
                    Debt = debt.Item1,
                    DueDate = dueDate.Item1,
                    Year = year.Item1,
                    InvoiceNumber = invoiceNumber.Item1
                }, 
                new SubscriberOriginal
                {
                    SubscriberNo = subscriberNo.Item2,
                    Debt = debt.Item2,
                    DueDate = dueDate.Item2,
                    Year = year.Item2,
                    InvoiceNumber = invoiceNumber.Item2
                }
            );
        }
        private Tuple<T, string> ParseLine<T>(string line, int startIndex, int endIndex)
        {
            string originalParsedValue;

            if (line.Length <= startIndex)
                originalParsedValue = string.Empty;
            else if (line.Length <= startIndex + endIndex)
                originalParsedValue = line.Substring(startIndex);
            else
                originalParsedValue = line.Substring(startIndex, endIndex);

            return Tuple.Create(originalParsedValue.Convert<T>(), originalParsedValue);
        }

        #endregion
    }
}