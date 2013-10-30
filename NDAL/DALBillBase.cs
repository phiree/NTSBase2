using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NModel;
namespace NDAL
{
  public   class DALBillBase:DalBase<BillBase>
    {
      public IList<BillBase> GetStockBill(StockActivityType type, int pageIndex, int pageSize, out int totalRecord)
      {
          string query = "select bs from BillStock bs where bs.StockActivityType= " + (int)type;

            return GetList(query,pageIndex,pageSize,out totalRecord);
      }
    }
}
