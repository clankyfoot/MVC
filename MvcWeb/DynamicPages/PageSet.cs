using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DynamicPages
{
    /// <summary>
    /// Responsible for the CRUD Entity Framework of the PageObjects
    /// </summary>
    public class PageSet : Abstract.Set<Models.PageObject>
    {
        protected const string CREATE_PAGE = "createPageObject";
        protected const string UPDATE_PAGE_ORDER_BYID = "updatePageOrderById";
        protected const string UPDATE_PAGE_ORDER_BYNAME = "updatePageOrderByName";
        protected const string UPDATE_PAGE_NAME = "updatePageName";
        protected const string DELETE_PAGE_BYID = "deletePageById";
        protected const string DELETE_PAGE_BYNAME = "deletePageByName";
        protected const string GET_PAGE_BY_ID = "getPageById";
        protected const string GET_PAGE_BY_NAME = "getPageByName";
        /// <summary>
        /// Default Constructors
        /// </summary>
        public PageSet()
        {
            
        }
        /// <summary>
        /// Creates a page
        /// </summary>
        /// <param name="name">name of the page</param>
        /// <returns>true if the procedure was successfull , else false</returns>
        public bool create(string name)
        {
            // ID and Order don't actually matter on the insert
            buildCommand(CREATE_PAGE, true, new Models.PageObject() { id = "0", name = name, order = "0" });
            return execute();
        }
        /// <summary>
        /// Updates the name of the page
        /// <param name="id">id of the page to be updated</param>
        /// <param name="newName">new name of the page</param>
        /// </summary>
        /// <returns>true if the procedure was successfull, else false</returns>
        public bool updatePageName(int id, string newName)
        {
            buildCommand(UPDATE_PAGE_NAME, true, new[] { "id", "name" }, new object[] { id, newName } );
            return execute();
        }
        /// <summary>
        /// Updates the order number in which the page is displayed
        /// <param name="id">id of the page to be updated</param>
        /// </summary>
        /// <returns>true if the procedure, else fasle</returns>
        public bool updatePageOrder(int id, int order)
        {
            buildCommand(UPDATE_PAGE_ORDER_BYID, true, new[] { "id", "order" }, new object[] { id, order });
            return execute();
        }
        /// <summary>
        /// Updates the order number in which the page is displayed
        /// </summary>
        /// <param name="name">name of the page to be updated</param>
        /// <returns>true if the procedure was successfull, else false</returns>
        public bool updatePageOrder(string name, int order)
        {
            buildCommand(UPDATE_PAGE_ORDER_BYNAME, true, new[] { "name", "order" }, new object[] { name, order });
            return execute();
        }
        /// <summary>
        /// Gets the page by the Unique ID
        /// </summary>
        /// <param name="id">Id of the page</param>
        /// <returns>A Single PageObject</returns>
        public Models.PageObject getPageById(int id)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Gets the page by name
        /// </summary>
        /// <param name="name">name of the page to be retrieved</param>
        /// <returns>A Single PageObject</returns>
        public Models.PageObject getPageByName(string name)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Deletes a page
        /// </summary>
        /// <returns>true if the procedure was successfull, else false</returns>
        public bool delete(int id)
        {
            buildCommand(DELETE_PAGE_BYID, true, "id", id);
            return execute();
        }
        /// <summary>
        /// Deletes a page
        /// </summary>
        /// <returns>true if the procedure was successfull, else false</returns>
        public bool delete(string name)
        {
            buildCommand(DELETE_PAGE_BYNAME, true, "name", name);
            return execute();
        }
    }
}