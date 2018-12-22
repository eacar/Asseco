using System;

namespace Core.Model.Exceptions
{
    [Serializable]
    public class FileException : Exception
    {
        #region Constructors

        public FileException(string message)
            : base(message)
        {
        }
        public FileException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        #endregion
    }
}