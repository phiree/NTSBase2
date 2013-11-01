using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NModel;
namespace NBiz
{
    public class BizStockBillDetail: BLLBase<StockBillDetail>
    {
        NDAL.DALStockBillDetail dalDetail = new NDAL.DALStockBillDetail();
        public IList<StockBillDetail> GetListByProduct(Guid ProductId)
        {
            return dalDetail.GetListByProduct(ProductId);
        }
    }
}
