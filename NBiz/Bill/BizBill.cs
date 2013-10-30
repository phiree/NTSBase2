using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NModel;
namespace NBiz
{
   public class BizBill:BLLBase<NModel.BillBase>
    {
       NDAL.DALBillBase DalStockBill = new NDAL.DALBillBase();
       public IList<BillBase> GetStockBill( StockActivityType type, int pageIndex, int pageSize, out int totalRecord)
       {
           return DalStockBill.GetStockBill(type, pageIndex, pageSize, out totalRecord);
       }
    }
}
