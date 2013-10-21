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
        public ProductCollection GetOneByUserAndName(string userId,string name)
        {
            ProductCollection pc= dal.GetOneByUserAndName(userId, name);
          
            return pc;
        }
        public ProductCollection GetDefaultCollection(string userId)
        {
            ProductCollection pc = dal.GetDefaultCollection(userId);
        
            if (pc == null)
            {
                pc = new ProductCollection();
                pc.UserId = new Guid(userId);
                pc.IsDefault = true;
                dal.Save(pc);
            }
            return pc;
        }
        public void AddToCollection(string[] productIdList, ProductCollection collection)
        { 
            
        }
    }
}
