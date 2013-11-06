﻿using System;
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
    }
}