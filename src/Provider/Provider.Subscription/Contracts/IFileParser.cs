using Provider.Subscription.Entities;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using Core.Model.Exceptions;

namespace Provider.Subscription.Contracts
{
    public interface IFileParser
    {
        #region Properties

        ConcurrentBag<Subscriber> ParsedSubscribers { get; }
        ConcurrentBag<SubscriberOriginal> UnparsedSubscribers { get; }

        #endregion

        #region Methods

        /// <summary>
        /// Parses the object with given filepath
        /// </summary>
        /// <exception cref="ProviderException"></exception>
        /// <exception cref="FileException"></exception>
        /// <param name="filePath"></param>
        /// <returns></returns>
        Task Parse(string filePath);

        /// <summary>
        /// Parses the object with given filepath and threadcount to boost performence.
        /// The optimimum value is 10.
        /// </summary>
        /// <exception cref="ProviderException"></exception>
        /// <exception cref="FileException"></exception>
        /// <param name="filePath"></param>
        /// <param name="threadCount"></param>
        /// <returns></returns>
        Task Parse(string filePath, int threadCount);

        #endregion
    }
}