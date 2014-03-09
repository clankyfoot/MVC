using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicPages.Interfaces
{
    interface ISet<EntityModel>
    {
        /// <summary>
        /// Creates an entity in the database
        /// </summary>
        /// <param name="model">model to be created</param>
        bool create(EntityModel model);
        /// <summary>
        /// updates an entity in the database
        /// </summary>
        /// <param name="model">model to update in the database</param>
        bool update(EntityModel model);
        /// <summary>
        /// deletes an entity in the database
        /// </summary>
        /// <param name="model">model to be deleted from the database</param>
        bool delete(EntityModel model);
        /// <summary>
        /// returns a list of all the current entity objects 
        /// in the database
        /// </summary>
        List<EntityModel> ToList();
    }
}
