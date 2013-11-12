using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NModel;
using NHibernate;
namespace NDAL
{
    public class DALBillInventory:DalBase<BillInventory>
    {
        public BillInventory GetProgressingInventory()
        {
           IQueryOver<BillInventory> qo= session.QueryOver<BillInventory>().Where(x => x.Status == EnumInventoryStatus.已开始);
           return GetOneByQuery(qo);
        }
    }
}
