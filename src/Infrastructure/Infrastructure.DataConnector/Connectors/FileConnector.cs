using Core.Model.Exceptions;
using Infrastructure.DataConnector.Contracts;
using System;
using System.IO.Abstractions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DataConnector.Connectors
{
    public class FileConnector : IFileConnector
    {
        #region Fields

        private readonly IFileSystem _fileSystem;

        #endregion

        #region Constructors

        public FileConnector(IFileSystem fileSystem)
        {
            _fileSystem = fileSystem;
        }

        #endregion

        #region Methods - Public - IFileConnector

        public async Task<string> ReadFile(string filePath, Encoding encoding, long maxFileSizeInBtyes)
        {
            var result = string.Empty;

            await Task.Run(() =>
            {
                try
                {
                    var fi = _fileSystem.FileInfo.FromFileName(filePath);
                    if (fi.Length > maxFileSizeInBtyes)
                    {
                        throw new FileException($"Current file's size is {fi.Length} bytes but cannot be more than {maxFileSizeInBtyes} bytes");
                    }
                    var uri = new Uri(filePath);
                    result = _fileSystem.File.ReadAllText(uri.LocalPath, encoding);
                }
                catch (FileException)
                {
                    throw;
                }
                catch (Exception ex)
                {
                    throw new ConnectorException($"File path {filePath} cannot be read with Encoding {encoding}", ex);
                }
            });

            return result;
        }

        #endregion

        #region Methods - Public - IDisposable

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
        ~FileConnector()
        {
            Dispose();
        }

        #endregion
    }
}