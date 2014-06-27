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
        public void SetDefaultCollection(string collectionId,string userid)
        {
            var old = GetDefaultCollection(userid);
            old.IsDefault = false;
            var newd = GetOne(new Guid(collectionId));
            newd.IsDefault = true;

            dal.Save(old);
            dal.Save(newd);
            
            
            
        }
        public ProductCollection CreateNew(string name, string userid)
        {
            ProductCollection pc = new ProductCollection();
            pc.UserId =new Guid(userid);
            pc.CollectionName = name;
            dal.Save(pc);
            return pc;
        }
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
        public void SaveCollectionWithName(Guid collectionid, string name)
        {
            
                ProductCollection oc = dal.GetOne(collectionid);
                oc.CollectionName = name;
                dal.Save(oc);
        }
        public IList<ProductCollection> GetCollectionList(string userid)
        {
            return dal.GetListByUserId(userid);
        }
        public void AddToCollection(string[] productIdList, ProductCollection collection)
        { 
            
        }
    }
}
