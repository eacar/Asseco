using System;
using System.ComponentModel;

namespace Core.Util.Extensions
{
    public static class ConversionExceptions
    {
        #region Methods - Public

        /// <summary>
        /// Converts any object to given type. However, the conversion type must be primitive struct.
        /// When ever an exception happens, the given default value of the conversion will be returned
        /// </summary>
        /// <typeparam name="TConvertionType"></typeparam>
        /// <param name="value"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static TConvertionType Convert<TConvertionType>(this object value, TConvertionType defaultValue = default(TConvertionType))
        {
            try
            {
                var converter = TypeDescriptor.GetConverter(typeof(TConvertionType));
                return (TConvertionType)converter.ConvertFromInvariantString(value.ToString());
            }
            catch (Exception)
            {
                return defaultValue;
            }
        }

        #endregion
    }
}