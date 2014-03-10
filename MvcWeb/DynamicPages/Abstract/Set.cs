using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DynamicPages.Abstract
{
    public abstract class Set<EntityModel> : Interfaces.ISet<EntityModel>
    {
        public string ConnectionString { get; set; }
        protected const string CREATE = "create";
        protected const string DELETE = "delete";
        protected const string UPDATE = "update";
        protected const string TOLIST = "ToList";
        /// <summary>
        /// Connection to the database
        /// </summary>
        private System.Data.SqlClient.SqlConnection connection { get; set; }
        /// <summary>
        /// command object to execute database queries
        /// </summary>
        private System.Data.SqlClient.SqlCommand command { get; set; }
        /// <summary>
        /// data reader to itterate through table data
        /// </summary>
        private System.Data.SqlClient.SqlDataReader reader { get; set; }
        /// <summary>
        /// A xml reader for the select commands
        /// </summary>
        private System.Xml.XmlReader xmlReader { get; set; }
        /// <summary>
        /// return value from NoneExecuteQuery() procedures
        /// </summary>
        private System.Data.SqlClient.SqlParameter returnValue { get; set; }
        /// <summary>
        /// Creates an entity object in the database
        /// </summary>
        /// <param name="model">Creates and Entity model in the database</param>
        public bool create(EntityModel model)
        {
            buildConnection();
            buildCommand(CREATE + typeof(EntityModel).Name, true);
            addParameters(model);
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
        /// Updates an Entity Model in the database
        /// </summary>
        /// <param name="model">Model to be updated</param>
        public bool update(EntityModel model)
        {
            buildCommand(UPDATE + typeof(EntityModel).Name, true);
            buildConnection();
            addParameters(model);
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
        /// deletes an entity model in the database
        /// </summary>
        /// <param name="model"></param>
        public bool delete(EntityModel model)
        {
            buildCommand(DELETE + typeof(EntityModel).Name, true);
            buildConnection();
            addParameters(model);
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
        /// Returns a list of all the entity models from the daabase
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<EntityModel> ToList()
        {
            System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
            buildConnection();
            buildCommand(TOLIST + typeof(EntityModel).Name, false);
            using(connection)
            {
                connection.Open();
                xmlReader = command.ExecuteXmlReader();
                if(xmlReader.Read())
                {
                    doc.Load(xmlReader);
                }
            }
            xmlReader.Dispose();
            GC.Collect();

            List<EntityModel> list = new List<EntityModel>();

            foreach(System.Xml.XmlNode node in doc.SelectNodes("/ROOT/row"))
            {
                EntityModel model = Activator.CreateInstance<EntityModel>();
                foreach(System.Xml.XmlNode data in node)
                {
                    model.GetType().GetProperty(data.Name).SetValue(model, data.InnerText);
                }
                list.Add(model);
            }

            return (list);
        }
        /// <summary>
        /// Builds the SqlConnection. By default this is the "DefaultConnection" string from the Web.Config file
        /// </summary>
        private void buildConnection()
        {
            if (ConnectionString == null)
            {
                ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            }
            connection = new System.Data.SqlClient.SqlConnection(ConnectionString);
        }
        /// <summary>
        /// Builds the SqlCommand object
        /// </summary>
        /// <param name="commandString">Query against the database</param>
        /// <param name="withReturnValue">If the query is not returning and data tables, this should be true</param>
        /// <exception cref="NullReferenceException">thrown when the connection object is not built</exception>"
        protected void buildCommand(string commandString, bool withReturnValue)
        {
            buildConnection();
            command = connection.CreateCommand();
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.CommandText = commandString;
            if(withReturnValue)
            {
                command.Parameters.Add((returnValue = new System.Data.SqlClient.SqlParameter()
                {
                    Direction = System.Data.ParameterDirection.ReturnValue
                }));
            }
        }
        /// <summary>
        /// Builds the SqlCommand object
        /// </summary>
        /// <param name="commandString">Query against the database</param>
        /// <param name="withReturnValue">If the query is not returning and data tables, this should be true</param>
        /// <param name="model">model to add all the parameters, and paramater values</param>
        /// <exception cref="NullReferenceException">thrown with with the connection object is not built</exception>
        protected void buildCommand(string commandString, bool withReturnValue, EntityModel model)
        {
            buildConnection();
            command = connection.CreateCommand();
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.CommandText = commandString;
            addParameters(model);
            if (withReturnValue)
            {
                command.Parameters.Add((returnValue = new System.Data.SqlClient.SqlParameter()
                {
                    Direction = System.Data.ParameterDirection.ReturnValue
                }));
            }
        }
        /// <summary>
        /// Builds the SqlCommand object
        /// </summary>
        /// <param name="commandString">Query against the database</param>
        /// <param name="withReturnValue">If the query is not returning and data tables, this should be true</param>
        /// <param name="parameter">parameter to be added to the query</param>
        /// <param name="parameterValue">value of the paramter to be added</param>
        protected void buildCommand(string commandString, bool withReturnValue, string parameter, object parameterValue)
        {
            buildConnection();
            command = connection.CreateCommand();
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.CommandText = commandString;
            addParameters(parameter, parameterValue);
            if (withReturnValue)
            {
                command.Parameters.Add((returnValue = new System.Data.SqlClient.SqlParameter()
                {
                    Direction = System.Data.ParameterDirection.ReturnValue
                }));
            }
        }
        /// <summary>
        /// Builds the SqlCommand object
        /// </summary>
        /// <param name="commandString">Query against the database</param>
        /// <param name="withReturnValue">If the query is not returning and data tables, this should be true</param>
        /// <param name="parameters">parameter(s) to be added to the query</param>
        /// <param name="parameterValues">value(s) of the paramter to be added</param>
        protected void buildCommand(string commandString, bool withReturnValue, string[] parameters, object[] parameterValues)
        {
            buildConnection();
            command = connection.CreateCommand();
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.CommandText = commandString;
            addParameters(parameters, parameterValues);
            if (withReturnValue)
            {
                command.Parameters.Add((returnValue = new System.Data.SqlClient.SqlParameter()
                {
                    Direction = System.Data.ParameterDirection.ReturnValue
                }));
            }
        }
        /// <summary>
        /// Adds all the public properties of a model as the names of the parameter matched with the value
        /// of the property
        /// </summary>
        /// <param name="model">Model of the public properties to be added</param>
        /// <exception cref="NullReferenceException">The command object is not built</exception>
        /// <exception cref="IndexOutOfBoundsException">The array went outside of the number of properties that were available in the loop</exception>
        protected void addParameters(EntityModel model)
        {
            System.Reflection.PropertyInfo[] properties = typeof(EntityModel).GetProperties();

            for(int i = 0; i < properties.Length; i++)
            {
                command.Parameters.AddWithValue(properties[i].Name, properties[i].GetValue(model));
            }
        }
        /// <summary>
        /// Adds parameters to the SqlCommand object
        /// </summary>
        /// <param name="parameter">name of the parameter being added</param>
        /// <param name="perameterValue">Value of the parameter being added</param>
        /// <exception cref="NullReferenceException">Throws this exception when the command is not built</exception>
        protected void addParameters(string parameter, object parameterValue)
        {
            command.Parameters.AddWithValue(parameter, parameterValue);
        }
        /// <summary>
        /// Adds parameters to the SqlCommand object
        /// </summary>
        /// <param name="paramters"></param>
        /// <param name="paramterValues"></param>
        /// <exception cref="NullReferenceException">This is thrown with the connection object is not built, or the command object is not built</exception>
        /// <exception cref="IndexOutOfRangeException">Exception thrown when the parameterValues are less than the parameters array</exception>
        private void addParameters(string[] paramters, object[] paramterValues)
        {
            for(int i = 0; i < paramters.Length; i++)
            {
                command.Parameters.AddWithValue(paramters[i], paramterValues[i]);
            }
        }
        /// <summary>
        /// Executes a "ExecuteNonQuery()" command against the database
        /// </summary>
        /// <returns></returns>
        public bool execute()
        {
            using(connection)
            {
                connection.Open();
                command.ExecuteNonQuery();
            }
            command.Dispose();
            GC.Collect();
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