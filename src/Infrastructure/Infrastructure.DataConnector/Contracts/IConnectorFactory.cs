namespace Infrastructure.DataConnector.Contracts
{
    public interface IConnectorFactory
    {
        /// <summary>
        /// Creates a file connector which loads a file and reads
        /// </summary>
        /// <returns></returns>
        IFileConnector CreateFileConnector();
    }
}