using System;

namespace Core.Model.Exceptions
{
    [Serializable]
    public class ProviderException : Exception
    {
        #region Constructors

        public ProviderException(string message)
            : base(message)
        {
        }
        public ProviderException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        #endregion
    }
}