using System.IO.Abstractions;
using Infrastructure.DataConnector.Contracts;

namespace Infrastructure.DataConnector.Connectors
{
    public class ConnectorFactory : IConnectorFactory
    {
        #region Fields

        private readonly IFileSystem _fileSystem;

        #endregion

        #region Constructors

        public ConnectorFactory(IFileSystem fileSystem)
        {
            _fileSystem = fileSystem;
        }

        #endregion

        #region Methods - Public - IConnectorFactory

        public IFileConnector CreateFileConnector()
        {
            return new FileConnector(_fileSystem);
        }

        #endregion
    }
}