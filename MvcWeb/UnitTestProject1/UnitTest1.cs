using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class PagesTest
    {
        DynamicPages.PageSet set = new DynamicPages.PageSet();
        /// <summary>
        /// Tests the CRUD statments of the DynamicPages namespace
        /// </summary>
        [TestMethod]
        public void createPage()
        {
            setConnectionString();
            set.create(new DynamicPages.Models.PageObject() { id = "0", name = "test", order = "1" });
        }
        /// <summary>
        /// Deletes a page from the database
        /// </summary>
        [TestMethod]
        public void deletePage()
        {
            setConnectionString();
            set.delete("test");
        }
        /// <summary>
        /// updates the name of a page
        /// </summary>
        [TestMethod]
        public void updatePageName()
        {
            setConnectionString();
            set.updatePageName(0, "new Test");
        }
        /// <summary>
        /// Updates the order of a page
        /// </summary>
        [TestMethod]
        public void updatePageOrder()
        {
            setConnectionString();
            set.updatePageOrder(0, 1);
        }
        /// <summary>
        /// Sets the connection
        /// </summary>
        public void setConnectionString()
        {
            set.ConnectionString = @"Data Source=(LocalDb)\v11.0;AttachDbFilename=C:\Users\CodeBracket\Documents\Visual Studio 2013\Projects\MVC\MvcWeb\MvcWeb\App_Data\MvcData.mdf;Integrated Security=True";
        }
    }
}
