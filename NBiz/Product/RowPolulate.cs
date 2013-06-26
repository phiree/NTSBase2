using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NModel;
using System.Data;
using NLibrary;
using System.Text.RegularExpressions;
namespace NBiz
{
    /// <summary>
    /// 用excel的每一行数据 构建一个product对象
    /// </summary>
    public class RowPopulateFactory
    {
        public static IRowPopulate CreatePopulator(DataTable dt)
        {
            if (dt.Columns.Count > 25)
                return new RowPolulateErp();
            else return new RowPolulateBaojiandan();
        }
    }
    public class RowPolulateBaojiandan : IRowPopulate
    {
        public Product PopulateFromRow(DataRow row)
        {
            //根据 名称值 判断该产品信息的语言.

            StringBuilder sb = new StringBuilder();
            Product p = new Product();
            ProductLanguage pl = new ProductLanguage();
            pl.Name = row["产品名称"].ToString();
            pl.Language = StringHelper.LanguageTypeDetermine(pl.Name);
            pl.PlaceOfOrigin = row["产地"].ToString();
            pl.PlaceOfDelivery = row["交货地"].ToString();
            p.ImageState = row["图片"].ToString();
            pl.Memo = row["备注"].ToString();
            p.PriceDate = row["报价日期"].ToString();
            p.PriceValidPeriod = row["报价有效期"].ToString();

            //分类编码:非空,格式正确
            string categoryCode = StringHelper.ReplaceSpace(row["分类编码"].ToString());
            if (string.IsNullOrEmpty(categoryCode))
            {
                string errmsg = string.Format("分类编码不能为空.可能原因:1)分类编码为空 2)有空白行.供应商编码:{0}", p.SupplierCode);
                NLibrary.NLogger.Logger.Error(errmsg);
                throw new Exception(errmsg);
            }
            string categoryCodePatern = @"\d{2}\.\d{3}";
            if (!Regex.IsMatch(categoryCode, categoryCodePatern))
            {
                string errmsg = string.Format("分类编码格式有误.名称:{0},编码:{1}", pl.Name, categoryCode);
                NLibrary.NLogger.Logger.Error(errmsg);
                throw new Exception(errmsg);
            }
            p.CategoryCode = categoryCode;
            //产品型号:特殊符号用美元符号代替
            string modelNumber = row["产品型号"].ToString();
            modelNumber = StringHelper.ReplaceInvalidChaInFileName(modelNumber, "$");

            p.ModelNumber = modelNumber;
            p.SupplierCode = row["供应商编码"].ToString();
            pl.ProductParameters = row["规格参数"].ToString();
            pl.Unit = row["单位"].ToString();
            pl.ProductDescription = row["产品描述"].ToString();
            p.MoneyType = row["币别"].ToString();
            //nts编码
            //已删除,该类不负责nts编码的创建

            //税率
            string strRate = row["税率"].ToString();
            strRate = strRate.Replace("%", "");
            if (!string.IsNullOrEmpty(strRate))
            {
                p.TaxRate = Convert.ToDecimal(strRate);
            }

            //出厂价
            decimal price = 0;
            string strFactoryPrice = row["出厂价"].ToString();
            if (!string.IsNullOrEmpty(strFactoryPrice))
            {
                try
                {
                    price = decimal.Parse(Regex.Replace(strFactoryPrice, @"[^\d.]", ""));
                }
                catch
                {
                    throw new Exception(string.Format("出厂价数据格式有误.供应商:{0},产品型号:{1}",
                                    p.SupplierCode, p.ModelNumber
                            ));
                }
            }
            p.PriceOfFactory = strFactoryPrice;
            //生产周期
            string productionCycle = row["生产周期"].ToString();
            int 生产周期 = 0;
            if (!string.IsNullOrEmpty(productionCycle))
            {
                生产周期 = int.Parse(Regex.Replace(productionCycle, @"[^\d.]", ""));
            }
            p.ProductionCycle = 生产周期;
            //最小订货量
            string strMinOrderAmount = row["最小起订量"].ToString();
            int 最小订货量 = 0;
            if (!string.IsNullOrEmpty(strMinOrderAmount))
            {
                if (!int.TryParse(Regex.Replace(strMinOrderAmount, @"[^\d.]", ""), out 最小订货量))
                {
                    NLibrary.NLogger.Logger.Debug(
                        string.Format(@"最小起定量数据格式异常,已设置为0.供应商:{0},产品型号:{1}"
                       , p.SupplierCode, p.ModelNumber
                        ));
                }
            }
            p.OrderAmountMin = 最小订货量;
          
            p.ProductMultiLangues.Add(pl);
            return p;
        }



    }
    public class RowPolulateErp : IRowPopulate
    {

        public Product PopulateFromRow(DataRow row)
        {
            Product p = new Product();
            ProductLanguage pl = new ProductLanguage();
            p.ProductMultiLangues.Add(pl);
            pl.PlaceOfOrigin = row["备注"].ToString();
            // p.PlaceOfDelivery = row["交货地"].ToString();
            pl.Name = row["名称"].ToString();
            pl.Language = StringHelper.LanguageTypeDetermine(pl.Name);
            string categoryCode = StringHelper.ReplaceSpace(row["代码"].ToString());

            if (string.IsNullOrEmpty(pl.PlaceOfOrigin) && string.IsNullOrEmpty(pl.Name)
                && string.IsNullOrEmpty(categoryCode))
            {
                throw new Exception("未导入.请确认非内容单元格已彻底清除.");
            }
            //erp的代码包含了供应商和流水号,应该去除
            if (string.IsNullOrEmpty(categoryCode))
            {
                string errmsg = string.Format("分类编码不能为空.名称:{0}", pl.Name);
                NLibrary.NLogger.Logger.Error(errmsg);
                throw new Exception(errmsg);
            }

            p.CategoryCode = categoryCode.Substring(0, 6);
            //产品型号:
            string modelNumber = row["产品型号"].ToString();
            p.ModelNumber = modelNumber;
            pl.ProductParameters = row["规格型号"].ToString();
            pl.Unit = row["计量单位组_FName"].ToString();
            p.SupplierCode = row["来源_FNumber"].ToString();
            pl.ProductDescription = row["描述/卖点"].ToString();
            //nts编码
            //已删除,该类不负责nts编码的创建

            //税率
            string strRate = row["税率(%)"].ToString();
            strRate = strRate.Replace("%", "");
            if (!string.IsNullOrEmpty(strRate))
            {
                p.TaxRate = Convert.ToDecimal(strRate);
            }

            //出厂价
            decimal price = 0;
            string strFactoryPrice = row["含税出厂价"].ToString();
            if (!string.IsNullOrEmpty(strFactoryPrice))
            {
                try
                {
                    price = decimal.Parse(Regex.Replace(strFactoryPrice, @"[^\d.]", ""));
                }
                catch
                {
                    throw new Exception(string.Format("出厂价数据格式有误.供应商:{0},产品型号:{1}",
                                    p.SupplierCode, p.ModelNumber
                            ));
                }
            }
            p.PriceOfFactory = strFactoryPrice;
            //生产周期
            string productionCycle = row["固定提前期"].ToString();
            int 生产周期 = 0;
            if (!string.IsNullOrEmpty(productionCycle))
            {
                生产周期 = int.Parse(Regex.Replace(productionCycle, @"[^\d.]", ""));
            }
            p.ProductionCycle = 生产周期;
            //最小订货量
            string strMinOrderAmount = row["最小订货量"].ToString();
            int 最小订货量 = 0;
            if (!string.IsNullOrEmpty(strMinOrderAmount))
            {
                if (!int.TryParse(Regex.Replace(strMinOrderAmount, @"[^\d.]", ""), out 最小订货量))
                {
                    NLibrary.NLogger.Logger.Debug(
                        string.Format(@"最小起定量数据格式异常,已设置为0.供应商:{0},产品型号:{1}"
                       , p.SupplierCode, p.ModelNumber
                        ));
                }
            }
            p.OrderAmountMin = 最小订货量;
            return p;
        }
    }
    public interface IRowPopulate
    {
        Product PopulateFromRow(DataRow row);
    }
}
