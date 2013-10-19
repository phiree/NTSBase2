using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NModel;
namespace NBiz
{
    public class BizProductCollection:BLLBase<ProductCollection>
    {
        NDAL.DALProductCollection dal = new NDAL.DALProductCollection();
        public BizProductCollection()
        { }
        public BizProductCollection(string userId)
        {
            ProductCollection pc = GetDefaultCollection(userId);
            if (pc==null)
            {
                pc = new ProductCollection();
                pc.UserId =new Guid(userId);
                pc.IsDefault = true;
                dal.Save(pc);
            }
        }
        public ProductCollection GetOneByUserAndName(string userId,string name)
        {
            return dal.GetOneByUserAndName(userId, name);

        }
        public ProductCollection GetDefaultCollection(string userId)
        {
            return dal.GetDefaultCollection(userId);
        }
        public void AddToCollection(string[] productIdList, ProductCollection collection)
        { 
            
        }
    }
}
