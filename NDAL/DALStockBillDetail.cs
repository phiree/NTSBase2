using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NModel;
namespace NDAL
{
   public class DALStockBillDetail:DalBase<StockBillDetail>
    {
       public IList<StockBillDetail> GetListByProduct(Guid productId)
       { 
        string query=@"select detail from StockBillDetail as detail 
                        inner join detail.Product as p 
                        where p.Id='"+productId+"'";
        return GetList(query);
       }
    }
}
