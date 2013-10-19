using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NModel;
namespace NDAL
{
    public class DALProductCollection : DalBase<ProductCollection>
    {

        public ProductCollection GetOneByUserAndName(string userId, string collectionName)
        {
            string query = "select c from ProductCollection c where c.UserId='" + userId
                          + "' and c.CollectionName='" + collectionName + "'";
            return GetOneByQuery(query);
        }


        public ProductCollection GetDefaultCollection(string userId)
        {
            string query = "select c from ProductCollection c where c.UserId='" + userId
                         + "' and c.IsDefault=1";
            return GetOneByQuery(query);
        }
    }
}
