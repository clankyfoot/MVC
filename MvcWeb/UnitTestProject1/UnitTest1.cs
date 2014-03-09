using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class PagesTest
    {
        /// <summary>
        /// Tests the CRUD statments of the DynamicPages namespace
        /// </summary>
        [TestMethod]
        public void TestMethod1()
        {
            DynamicPages.PageSet set = new DynamicPages.PageSet();
            set.ConnectionString = @"Data Source=(LocalDb)\v11.0; AttachDbFileName=|DataDirectory|\MvcData.mdf; Integrated Security=SSPI;";
            set.create(new DynamicPages.Models.PageObject() { id = "0", name = "test", order = "1" });
        }
    }
}
