using AntYecai.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AntYecaiTest.Utils
{
    [TestClass()]
    public class MD5SignatureUtilTest
    {
        [TestMethod()]
        public void GetSignAsHexTest()
        {
            string rowText = "ant111AntLogin";
            string expected = "71736cfd60d4523017cc23ae12231c13";
            string actual;
            actual = MD5SignatureUtil.GetSignAsHex(rowText);
            Assert.AreEqual(expected, actual);
        }
    }
}
