using System;

namespace Core.Model.Exceptions
{
    [Serializable]
    public class ConnectorException : Exception
    {
        #region Constructors

        public ConnectorException(string message)
            : base(message)
        {
        }
        public ConnectorException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        #endregion
    }
}