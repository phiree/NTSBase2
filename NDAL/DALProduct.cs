using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NModel;
using NLibrary;
namespace NDAL
{
    /// <summary>
    /// 数据库层 不要做任何逻辑判断~!~~~~~~~~~~~~
    /// </summary>
    public class DALProduct : DalBase<NModel.Product>
    {
        public string SaveMsg { get; private set; }
        /*
        public override void Save(NModel.Product o)
        {
            
            var q = session.QueryOver<Product>().Where(x => x.SupplierCode == o.SupplierCode)
                .And(x => x.ModelNumber == o.ModelNumber)
                .List();

            if (q.Count > 0)
            {    
                if (q.Count == 1)
                {
                    Product existedOne = q[0];
                    SaveMsg = string.Format("存在同厂同型产品,已更新.名称:{0};型号:{1};供应商:{2}",q[0].Name,q[0].ModelNumber,q[0].SupplierName);
                    existedOne.CopyFrom(o);
                    existedOne.NTSCode = o.NTSCode;
                    base.Update(existedOne);
                    o = existedOne;
                }
                else
                {

                    string errMsg = "未保存.已存在相同供应商和型号的产品:" + o.Name + "-" + o.SupplierName + "-" + o.ModelNumber;
                    NLibrary.NLogger.Logger.Debug(errMsg);
                    throw new Exception(errMsg);
                }
            }
            else
            {
                base.Save(o);
            }
        }*/
        public virtual Product GetOneByModelNumberAndSupplierCode(string modelNumber, string supplierCode)
        {
            NHibernate.IQueryOver<Product> iqueryover = session.QueryOver<Product>().Where(x => x.SupplierCode == supplierCode)
                .And(x => x.ModelNumber == modelNumber);
            //string query = string.Format("from Product p where p.SupplierName='{0}' and p.ModelNumber='{1}'",
            //    supplierName,modelNumber);
            try
            {
                Product p = GetOneByQuery(iqueryover);

                return p;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + "Data:modelnumber:" + modelNumber + "--suppliercode:" + supplierCode);
            }
            // return GetOneByQuery(iqueryover);
        }
        public virtual Product GetOneByNTSCode(string ntscode)
        {
            NHibernate.IQueryOver<Product> iqueryover = session.QueryOver<Product>().Where(x => x.NTSCode == ntscode)
              ;
            //string query = string.Format("from Product p where p.SupplierName='{0}' and p.ModelNumber='{1}'",
            //    supplierName,modelNumber);
            try
            {
                Product p = GetOneByQuery(iqueryover);

                return p;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + "数据不存在. Data:NTSCode:" + ntscode);
            }
        }
        /*
        public virtual Product GetOneByModelNumberAndSupplierName(string modelNumber, string suppliername, string supplierEnglishName)
        {
            NHibernate.IQueryOver<Product> iqueryover = session.QueryOver<Product>().Where(x => x.ModelNumber == modelNumber)
                 .And(x => x.SupplierName == suppliername || x.SupplierName == supplierEnglishName);
            //  string query = string.Format("from Product p where p.SupplierName='{0}' and p.ModelNumber='{1}'",
            //    supplierName,modelNumber);
            try
            {
                Product p = GetOneByQuery(iqueryover);

                return p;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + "Data:modelnumber:" + modelNumber + "--supplierName:" + suppliername);
            }
        }
        */
        /// <summary>
        /// 通用搜索.
        /// </summary>
        /// <param name="supplierName"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="totalRecord"></param>
        /// <returns></returns>
        public IList<Product> Search(string supplierName, string model, bool? hasphoto,
            string name, string categorycode,
            string ntsCode,
            int pageSize, int pageIndex, out int totalRecord)
        {

            //string query = "select p from Product as  p join p.ProductMultiLangues as pl where ";
            string select = "select distinct p ";
            string selectCount = "select count(distinct p) ";
            string from = " from Product as p join p.ProductMultiLangues as pl ";
            string where = " where ";

            if (!string.IsNullOrEmpty(supplierName))
            {
                where += "  p.SupplierCode in (select s.Code from Supplier as s where s.EnglishName like '%" + supplierName + "%' or  s.Name like '%" + supplierName + "%') ";
            }
            else
            {
                where += " 1=1  ";
            }
            if (!string.IsNullOrEmpty(ntsCode))
            {
                where += " and p.NTSCode like '%" + ntsCode + "%'";
            }

            if (!string.IsNullOrEmpty(model))
            {
                where += "and p.ModelNumber like '%" + model + "%'";
            }
            if (hasphoto.HasValue)
            {
                if (hasphoto.Value == true)
                {
                    where += "and p.ProductImageList.size>0";
                }
                else
                {
                    where += "and p.ProductImageList.size=0";
                }
            }
            if (!string.IsNullOrEmpty(name))
            {
                where += string.Format(" and  pl.Name like '%{0}%'", name);
            }
            if (!string.IsNullOrEmpty(categorycode))
            {
                //02 或者 02.001
                where += string.Format(" and (p.CategoryCode='{0}' or substring(p.CategoryCode,1,2)='{0}')", categorycode);
            }
            string query = select + from + where;
            string queryCount = selectCount + from + where;
            string orderColumns = " p.LastUpdateTime ";
            bool desc = true;

            return GetList(query, orderColumns, desc, pageIndex, pageSize, out totalRecord, queryCount);
        }

        /// <summary>
        /// 精确获取供应商的产品
        /// </summary>
        /// <param name="supplierName"></param>
        /// <returns></returns>
        public IList<Product> GetListBySupplier(string supplierCode)
        {
            NHibernate.IQueryOver<Product, Product> queryover = session.QueryOver<Product>()
                .Where(x => x.SupplierCode == supplierCode)

                ;
            return GetList(queryover);
        }

        public virtual IList<Product> GetListBySupplierCode(string supplierCode)
        {
            NHibernate.IQueryOver<Product, Product> queryover = session.QueryOver<Product>()
                .Where(x => x.SupplierCode == supplierCode);
            //var list= session.QueryOver<Product>().Where(x => x.SupplierCode == supplierCode);

            //string qry = "select p from Product p where p.SupplierCode='" + supplierCode + "'";
            //return GetList(qry);

            return GetList(queryover);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="beginDate">哪一天之后导入的.</param>
        /// <returns></returns>
        public IList<Product> GetProducts_English(DateTime beginDate)
        {
            string query = "select p from Product p where p.Language='en' and lastupdatetime>'" + beginDate + "'";
            int totalRecord;
            return GetList(query, "NTSCode", false, 0, 99999, out totalRecord, string.Empty);
        }

        public IList<Product> GetProductsNoImages()
        {
            string query = "select p from Product p where  p.ProductImageList.size=0";
            int totalRecord;
            return GetList(query, "SupplierCode", false, 0, 99999, out totalRecord, string.Empty);
        }
    }
}
