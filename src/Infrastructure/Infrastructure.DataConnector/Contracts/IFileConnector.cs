using System;
using System.Text;
using System.Threading.Tasks;
using Core.Model.Exceptions;

namespace Infrastructure.DataConnector.Contracts
{
    public interface IFileConnector : IDisposable
    {
        /// <summary>
        /// Reads file of given path with given encoding.
        /// Also, file must be within the given flie size. Otherwise, <exception cref="ConnectorException"></exception> will
        /// be thrown.
        /// </summary>
        /// <exception cref="ConnectorException"></exception>
        /// <exception cref="FileException"></exception>
        /// <param name="filePath"></param>
        /// <param name="encoding"></param>
        /// <param name="maxFileSizeInBtyes"></param>
        /// <returns></returns>
        Task<string> ReadFile(string filePath, Encoding encoding, long maxFileSizeInBtyes);
    }
}