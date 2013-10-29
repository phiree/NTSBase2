using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
namespace NModel.Mapping
{
    public class StockBillDetailMap : ClassMap<StockBillDetail>
    {
        public StockBillDetailMap()
        {
            Id(x => x.Id);
            References<BillBase>(x => x.Bill);
            Map(x => x.Location);
            References<Product>(x => x.Product);
            Map(x => x.Stock);
            Map(x => x.StockUnit);
            Map(x => x.UpdateTime);
            Map(x => x.TotalMoney);

        }
    }
}
