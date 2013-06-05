﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using NModel;
namespace NBiz
{
    public class CategoryDataTableConverter : IDataTableConverter<NModel.Category>
    {
        public IList<NModel.Category> Convert(DataTable dt)
        {
           
            IList<Category> categories = new List<Category>();
            
            foreach (DataRow row in dt.Rows)
            {
                Category cate = new Category();
                //分类编码	上级编码	中文名称	英文名称

                cate.Code = row["分类编码"].ToString();
                cate.EnglishName = row["英文名称"].ToString();
                cate.Memo = row["备注"].ToString();
                cate.Name = row["中文名称"].ToString();
                cate.ParentCode = row["大类编码"].ToString();
                categories.Add(cate);
            }

            return categories;
        }
    }
}
