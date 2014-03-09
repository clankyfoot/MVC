using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcWeb.Controllers
{
    [HandleError]
    public class PageController : Controller
    {
        private DynamicPages.PageSet set = new DynamicPages.PageSet();
        /// <summary>
        /// loads a list of all the pages
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            set.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            return View(set.ToList());
        }
        /// <summary>
        /// Creates a page
        /// </summary>
        /// <param name="pageName">name of the page</param>
        /// <returns></returns>
        [HttpPost]
        [AcceptVerbs(HttpVerbs.Post)]
        //[ValidateAntiForgeryToken]
        public bool createPage(string name)
        {
            return set.create(name);
        }
        /// <summary>
        /// Deletes a page 
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [AcceptVerbs(HttpVerbs.Post)]
        //[ValidateAntiForgeryToken]
        public bool deletePage(object idOrName)
        {
            bool ret = false;
            set.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            switch (idOrName.GetType().Name)
            {
                case "String":
                case "string":
                    ret = set.delete((string)idOrName);
                    break;
                case "Int32":
                case "Int64":
                    ret = set.delete((int)idOrName);
                    break;
                default:
                    break;
            }

            return ret;
        }
        /// <summary>
        ///  Updates a Page name
        /// </summary>
        /// <param name="id">Id if of the page</param>
        /// <param name="name">new name of the page</param>
        /// <returns></returns>
        [HttpPost]
        [AcceptVerbs(HttpVerbs.Post)]
        public bool updatePageName(int id, string name)
        {
            set.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            return set.updatePageName(id, name);
        }
        /// <summary>
        /// Updates the display order of a page
        /// </summary>
        /// <param name="idOrName">id or name of the page</param>
        /// <param name="order">new order number</param>
        /// <returns></returns>
        [HttpPost]
        [AcceptVerbs(HttpVerbs.Post)]
        public bool updatePageOrder(object idOrName, int order)
        {
            bool ret = false;
            set.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            switch (idOrName.GetType().Name)
            {
                case "String":
                case "string":
                    ret = set.updatePageOrder((string)idOrName, order);
                    break;
                case "Int32":
                case "Int64":
                    ret = set.updatePageOrder((int)idOrName, order);
                    break;
                default:
                    break;
            }

            return ret;
        }
    }
}
