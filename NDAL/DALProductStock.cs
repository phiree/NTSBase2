using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NModel;
namespace NDAL
{
    public class DALProductStock:DalBase<ProductStock>
    {
        public ProductStock GetByProductId(Guid id)
        {
            string query = @"select ps from ProductStock as  ps inner join ps.Product as p
                                where p.Id='"+id+"'";
            return GetOneByQuery(query);
        }
        public ProductStock GetByProductNtsCode(string ntsCode)
        {
            string query = @"select ps from ProductStock as  ps inner join ps.Product as p
                                where p.NTSCode='" + ntsCode + "'";
            return GetOneByQuery(query);
        }
        public IList<ProductStock> GetListByNtsCodeList(string[] ntsCodeList)
        {
            int totalRecord;
            string condition_In = string.Empty;
            foreach (string ntsCode in ntsCodeList)
            {
                condition_In +="'"+ntsCode + "',";
            }
            condition_In = " (" + condition_In.TrimEnd(',') + ") ";
            string query = @"select ps from ProductStock ps 
                                    inner join ps.Product p 
                                where p.NTSCode in " + condition_In;
            return GetList(query, 0, 999, out totalRecord);
        }
    }
}
