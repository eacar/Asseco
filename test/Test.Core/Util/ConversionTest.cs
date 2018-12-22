using Core.Util.Extensions;
using Xunit;

namespace Test.Core.Util
{
    /// <summary>
    /// This test can be extented with multiple varations of many types. Currently, only
    /// string to int is tested
    /// </summary>
    public class ConversionTest
    {
        #region	Tests

        [Theory]
        [InlineData("-3333333333333333")] //The exceptions should return given type's default
        [InlineData("-2147483647")]
        [InlineData("2147483647")]
        [InlineData("3786123")]
        [InlineData("32311")]
        public void Convert_StringToInt_SuccessAndFail(string value)
        {
            #region	Acts

            var result = value.Convert<int>();

            #endregion

            #region	Asserts

            int.TryParse(value, out var rsp);

            Assert.Equal(rsp, result);

            #endregion
        }

        #endregion
    }
}