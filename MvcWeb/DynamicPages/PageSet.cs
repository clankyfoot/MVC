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
            buildConnection();
            buildCommand(CREATE_PAGE, true);
            // the id and order actually don't matter for this insert
            addParameters(new Models.PageObject() { id = "0", name = name, order = "0" });
            using(connection)
            {
                connection.Open();
                command.ExecuteNonQuery();
            }
            command.Dispose();
            GC.Collect();
            if((int)returnValue.Value == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Updates the name of the page
        /// <param name="id">id of the page to be updated</param>
        /// <param name="newName">new name of the page</param>
        /// </summary>
        /// <returns>true if the procedure was successfull, else false</returns>
        public bool updatePageName(int id, string newName)
        {
            buildConnection();
            buildCommand(UPDATE_PAGE_NAME, true);
            addParameters("id", id);
            addParameters("name", newName);
            using(connection)
            {
                connection.Open();
                command.ExecuteNonQuery();
            }
            if((int)returnValue.Value == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Updates the order number in which the page is displayed
        /// <param name="id">id of the page to be updated</param>
        /// </summary>
        /// <returns>true if the procedure, else fasle</returns>
        public bool updatePageOrder(int id, int order)
        {
            buildCommand(UPDATE_PAGE_ORDER_BYID, true);
            buildConnection();
            addParameters("id", id);
            addParameters("order", order);
            using(connection)
            {
                connection.Open();
                command.ExecuteNonQueryAsync();
            }
            if((int)returnValue.Value == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Updates the order number in which the page is displayed
        /// </summary>
        /// <param name="name">name of the page to be updated</param>
        /// <returns>true if the procedure was successfull, else false</returns>
        public bool updatePageOrder(string name, int order)
        {
            buildCommand(UPDATE_PAGE_ORDER_BYNAME, true);
            buildConnection();
            addParameters("name", name);
            addParameters("order", order);
            using (connection)
            {
                connection.Open();
                command.ExecuteNonQueryAsync();
            }
            if ((int)returnValue.Value == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
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
        public bool deletePage(int id)
        {
            buildConnection();
            buildCommand(DELETE_PAGE_BYID, true);
            addParameters("id", id);
            using (connection)
            {
                connection.Open();
                command.ExecuteNonQuery();
            }
            if ((int)returnValue.Value == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Deletes a page
        /// </summary>
        /// <returns>true if the procedure was successfull, else false</returns>
        public bool deletePage(string name)
        {
            buildCommand(DELETE_PAGE_BYNAME, true);
            buildConnection();
            addParameters("name", name);
            using (connection)
            {
                connection.Open();
                command.ExecuteNonQuery();
            }
            if ((int)returnValue.Value == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}