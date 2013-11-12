using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NModel;
using NDAL;
namespace NBiz.Bill
{
   public class BizBillInventory
    {
       DALBillInventory dalBi = null;
       public DALBillInventory DalBI {
           get {
               if (dalBi == null)
                   dalBi= new DALBillInventory();
               return dalBi;
           }
       }
       public bool BeginCheck()
       {
           BillInventory biProgressing = DalBI.GetProgressingInventory();
           return biProgressing != null;
       }
       /*
        三大规则
        * 1 Open-Close class should be open for extension and close for modification
        * 2 对内开放 对外透明
        */
       private BillInventory GetProgressingInventory()
       {
           return DalBI.GetProgressingInventory();
       }
    }
}
