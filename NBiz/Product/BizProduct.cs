using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NModel;
using NDAL;
using NLibrary;
using System.Data;
using System.IO.Compression;
namespace NBiz
{
    /// <summary>
    /// 产品业务类.
    /// </summary>
    public class BizProduct : BLLBase<NModel.Product>
    {
       
        //NTS编码维护类.
        FormatSerialNoUnit serialNoUnit;
        public FormatSerialNoUnit SerialNoUnit
        {
            get
            {
                if (serialNoUnit == null)
                {
                    serialNoUnit = new FormatSerialNoUnit(new DALFormatSerialNo());
                }
                return serialNoUnit;
            }
        }

        DALSupplier _dalSupplier;
        public DALSupplier DalSupplier
        {
            get
            {
                if (_dalSupplier == null)
                {
                    _dalSupplier = new DALSupplier();
                }
                return _dalSupplier;

            }
            set
            {
                _dalSupplier = value;
            }
        }
        DALProduct dalProduct = new DALProduct();
        public DALProduct DalProduct
        {
            get
            {
                if (dalProduct == null) dalProduct = new DALProduct();
                return dalProduct;
            }
            set
            {
                dalProduct = value;
            }
        }
        BizSupplier BizSp;
        public string ImportMsg { get; set; }
        public BizProduct()
        {
            if (BizSp == null) BizSp = new BizSupplier();
        }
        /// <summary> 导入excel产品列表

        /// </summary>
        /// <param name="stream">excel流</param>
        /// <param name="errMsg"></param>
        public IList<Product> ImportProductFromExcel(System.IO.Stream stream, out string errMsg)
        {
            IDataTableConverter<Product> productReader = new ProductDataTableConverter();
            ImportToDatabaseFromExcel<Product> importor = new ImportToDatabaseFromExcel<Product>(productReader, this);
            return importor.ImportXslData(stream, out  errMsg);
        }
        /// <summary>
        /// 压缩包
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="errMsg"></param>
        /// <returns></returns>
        public IList<Product> ImportProductFromZip(System.IO.Stream stream, out string errMsg)
        {
            errMsg = string.Empty;
            GZipStream gs = new GZipStream(stream, CompressionMode.Decompress);
            return null;
        }
        /// <summary> 从excel文件中读取产品信息
        ///
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="errMsg"></param>
        /// <returns></returns>
        public IList<Product> ReadListFromExcel(System.IO.Stream stream, out string errMsg)
        {
            IDataTableConverter<Product> productReader = new ProductDataTableConverter();
            ImportToDatabaseFromExcel<Product> importor = new ImportToDatabaseFromExcel<Product>(productReader, this);
            return importor.ReadList(stream, out  errMsg);
        }
        /// <summary>
        /// 从excel文件中读取产品信息和内嵌图片
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="errMsg"></param>
        /// <param name="allPictures"></param>
        /// <returns></returns>
        public IList<Product> ReadListFromExcelWithAllPictures(System.IO.Stream stream, out string errMsg, out System.Collections.IList allPictures)
        {
            IDataTableConverter<Product> productReader = new ProductDataTableConverter();
            ImportToDatabaseFromExcel<Product> importor = new ImportToDatabaseFromExcel<Product>(productReader, this);
            return importor.ReadList(stream, out  errMsg, out allPictures);
        }
        /// <summary>
        /// 保存产品列表至数据库
        /// </summary>
        /// <param name="list"></param>
        /// <param name="totalErrMsg"></param>
        /// <returns>成功保存的总数</returns>
        public override IList<Product> SaveList(IList<Product> list, out string totalErrMsg)
        {
            totalErrMsg = string.Empty;
            StringBuilder sbMsg = new StringBuilder();
            sbMsg.AppendLine("-----开始保存.产品数量:" + list.Count + "<br/>");
            IList<Product> existedItems;
            var listToBeSaved = CheckSupplierExisted(list, out existedItems);
            //排除已有产品 之前是在dal层实现,应该转移到bll层, 因为nts编码生成也与此相关.
            //已经提取出来的supplier直接获取 不再从数据源提取
            sbMsg.AppendLine("---------可导入/待导入数量:" + listToBeSaved.Count + "/" + list.Count + "<br/>");

            foreach (Product p in listToBeSaved)
            {
                if (string.IsNullOrEmpty(p.NTSCode))
                {
                    p.NTSCode = SerialNoUnit.GetFormatedSerialNo(p.CategoryCode + "." + p.SupplierCode);
                    string proCate = p.CategoryCode.Replace(".", string.Empty);
                    //修改条形码规则,增加三位小类
                    //string topCateForProductCode = BizHelper.GetFirstCateCode(proCate);
                    p.ProductCode = SerialNoUnit.GetFormatedSerialNo(proCate);
                }
            }
            DalProduct.SaveList(listToBeSaved);
            sbMsg.AppendLine("---------导入完成----:" + listToBeSaved.Count + "<br/>");
            SerialNoUnit.Save();
            sbMsg.AppendLine("---------NTS编码已生成----:" + listToBeSaved.Count + "<br/>");
            sbMsg.AppendLine("--数据导入结束----:" + listToBeSaved.Count + "<br/>");
            totalErrMsg=ImportMsg = sbMsg.ToString();
            return listToBeSaved;

        }
        /// <summary>
        ///   该产品是否已经存在,更新供应商Code
        /// </summary>
        /// <param name="list">待检查列表</param>
        /// <param name="invalidItems">不合格数据</param>
        /// <param name="outErrMsg">错误信息</param>
        /// <returns>合格数据,可以直接导入</returns>
        public IList<Product> CheckSupplierExisted(IList<Product> list, out IList<Product> existedItems)
        {
            existedItems = new List<Product>();
            IList<Product> ValidItems = new List<Product>();//没有重复的产品

            foreach (Product o in list)
            {
                Supplier s =  BizSp.GetByCode(o.SupplierCode);
                if (s == null)
                {
                    throw new Exception("供应商不存在:" + o.SupplierCode + ",请检查Excel的供应商列.");
                }
                var p = DalProduct.GetOneByModelNumberAndSupplierCode(o.ModelNumber, s.Code);
                if (p != null)
                {
                    p.UpdateByNewVersion(o);
                    //---------------------------新上传的数据 可以覆盖旧数据-------------------------
                    ValidItems.Add(p);
                    existedItems.Add(o);
                    continue;
                }

                ValidItems.Add(o);
            }
            return ValidItems;
        }
        public IList<Product> Search(string supplierName, string model, bool? hasPhoto,
            string name, string categorycode,
            string ntsCode,
            string imageQuality,
            string delivery,
            string original,string expireddate,
            string procode,
            string lang,
            int pageSize, int pageIndex, out int totalRecord)
        {
            return DalProduct.Search(supplierName, model, hasPhoto,
               name, categorycode,
               ntsCode,
               imageQuality,
               delivery,
               original,
               expireddate,
        procode,
        lang,
               pageSize, pageIndex, out totalRecord);
        }

        public Product GetOneBy_SupplierCode_ModelNumber(string supplierCode, string modelNumber)
        {
            Supplier s = BizSp.GetByCode(supplierCode);
            if (s == null)
                return null;

            return DalProduct.GetOneByModelNumberAndSupplierCode(modelNumber, supplierCode);
        }

        public Product GetOneBy_NtsCode(string  ntscode)
        {
           return DalProduct.GetOneByNTSCode(ntscode);
        }
        public IList<Product> GetListBySupplierCode(string supplierCode)
        {
            return DalProduct.GetListBySupplierCode(supplierCode);
        }
        public IList<Product> GetListByNTSCodeList(string[] ntsCodeList)
        {
            return DalProduct.GetListByNTSCodeList(ntsCodeList);
        }
        /// <summary>
        /// 从字符串提取产品关键信息,进而从数据库中提取相关信息
        /// </summary>
        /// <param name="providedList">字符串要求 型号---供应商编码</param>
        /// <param name="inValidRows">无法从这些信息中获取产品信息</param>
        /// <returns></returns>
        public IList<Product> GetListByProvidedModelNumberSupplierNameList(string providedList, out string msg)
        {
            string[] rows = providedList.Split(new string[]{ Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries);
            IStringPopulate strPopulate = StringPopulateFactory.CreateInstance("sm");

            IList<Product> products = new List<Product>();
            msg = string.Empty;
            foreach (string row in rows)
            {
                Product p = strPopulate.Populate(row, this);
                if (p != null)
                {
                    products.Add(p);
                }
                else
                {
                    msg +="无法获取相关信息:"+ row + Environment.NewLine;
                }
            }
            return products;

        }

        /// <summary>
        /// 翻译过的产品资料
        /// </summary>
        /// <returns></returns>
        public IList<Product> GetProducts_English(DateTime begindate)
        {
            return DalProduct.GetProducts_English(begindate);
        }
        public IList<Product> GetProductsNoImages()
        {
            return DalProduct.GetProductsNoImages();
        }



        internal  IList<Product> GetNotSyncProduct()
        {
            return DalProduct.GetNotSyncProduct();
        }
        internal DataSet ConvertToErpFormat(IList<Product> products)
        {
            DataTable dtForErp = new DataTable();
            string[] columnNames = {"代码",	"名称",	"明细",	"审核人_FName",	"物料全名",
                                   "助记码",	"规格型号",	"辅助属性类别_FName",
                                   "辅助属性类别_FNumber",	"物料属性_FName",
                                   "物料分类_FName",	"计量单位组_FName",	
                                   "基本计量单位_FName",	"基本计量单位_FGroupName",
                                   "采购计量单位_FName",	"采购计量单位_FGroupName",
                                   "销售计量单位_FName",	"销售计量单位_FGroupName",
                                   "生产计量单位_FName",	"生产计量单位_FGroupName",	
                                   "库存计量单位_FName",	"库存计量单位_FGroupName",
                                   "辅助计量单位_FName",	"辅助计量单位_FGroupName",	
                                   "辅助计量单位换算率",	"默认仓库_FName",	"默认仓库_FNumber",	
                                   "默认仓位_FName",	"默认仓位_FGroupName",	"来源_FName",
                                   "来源_FNumber",	"数量精度",	"最低存量",	"最高存量",	"安全库存数量",	
                                   "使用状态_FName",	"是否为设备",	"设备编码",	"是否为备件",	"批准文号",
                                   "别名",	"物料对应特性",	"默认待检仓库_FName",	"默认待检仓库_FNumber",
                                   "默认待检仓位_FName",	"默认待检仓位_FGroupName",	"币别_FName",	"币别_FNumber",
                                   "采购最高价",	"采购最高价币别_FName",	"采购最高价币别_FNumber",	"委外加工最高价",	
                                   "委外加工最高价币别_FName",	"委外加工最高价币别_FNumber",	"销售最低价",
                                   "销售最低价币别_FName",	"销售最低价币别_FNumber",	"是否销售",	"采购负责人_FName",	
                                   "采购负责人_FNumber",	"毛利率",	"采购单价",	"销售单价",	"是否农林计税",	
                                   "是否进行保质期管理",	"保质期天",	"是否需要库龄管理",	"是否采用业务批次管理",	
                                   "是否需要进行订补货计划的运算",	"失效提前期天",	"盘点周期单位_FName",
                                   "盘点周期",	"每周月第天",	"上次盘点日期",	"外购超收比例",	"外购欠收比例",	
                                   "销售超交比例",	"销售欠交比例",	"完工超收比例",	"完工欠收比例",	"领料超收比例",
                                   "领料欠收比例",	"计价方法_FName",	"计划单价",	"单价精度",	"存货科目代码_FNumber",	
                                   "销售收入科目代码_FNumber",	"销售成本科目代码_FNumber",	"成本差异科目代码_FNumber",
                                   "代管物资科目_FNumber",	"税目代码_FName",	"税率",	"成本项目_FName",
                                   "成本项目_FNumber",	"是否进行序列号管理",	"参与结转式成本还原",	"备注",
                                   "计划策略_FName",	"计划模式_FName",	"订货策略_FName",	"固定提前期",
                                   "变动提前期",	"累计提前期",	"订货间隔期天",	"最小订货量",	"最大订货量",
                                   "批量增量",	"设置为固定再订货点",	"再订货点",	"固定经济批量",	"变动提前期批量",
                                   "批量拆分间隔天数",	"拆分批量",	"需求时界天",	"计划时界天",	
                                   "默认工艺路线_FInterID",	"默认工艺路线_FRoutingName",	"默认生产类型_FName",
                                   "默认生产类型_FNumber",	"生产负责人_FName",	"生产负责人_FNumber",
                                   "计划员_FName",	"计划员_FNumber",	"是否倒冲",	"倒冲仓库_FName",
                                   "倒冲仓库_FNumber",	"倒冲仓位_FName",	"倒冲仓位_FGroupName",	
                                   "投料自动取整",	"日消耗量",	"MRP计算是否合并需求",	"MRP计算是否产生采购申请",
                                   "控制类型_FName",	"控制策略_FName",	"容器名称",	"看板容量",	"图号",	
                                   "是否关键件",	"毛重",	"净重",	"重量单位_FName",	"重量单位_FGroupName",	
                                   "长度",	"宽度",	"高度",	"体积",	"长度单位_FName",	"长度单位_FGroupName",	
                                   "版本号",	"单位标准成本",	"附加费率",	"附加费所属成本项目_FNumber",	"成本BOM_FBOMNumber",
                                   "成本工艺路线_FInterID",	"成本工艺路线_FRoutingName",	"标准加工批量",	"单位标准工时小时",	
                                   "标准工资率",	"变动制造费用分配率",	"单位标准固定制造费用金额",	"单位委外加工费",
                                   "委外加工费所属成本项目_FNumber",	"单位计件工资",	"采购订单差异科目代码_FNumber",
                                   "采购发票差异科目代码_FNumber",	"材料成本差异科目代码_FNumber",
                                   "加工费差异科目代码_FNumber",	"废品损失科目代码_FNumber",	"标准成本调整差异科目代码_FNumber",
                                   "采购检验方式_FName",	"产品检验方式_FName",	"委外加工检验方式_FName",	"发货检验方式_FName",
                                   "退货检验方式_FName",	"库存检验方式_FName",	"其他检验方式_FName",	"抽样标准致命_FName",
                                   "抽样标准致命_FNumber",	"抽样标准严重_FName",	"抽样标准严重_FNumber",
                                   "抽样标准轻微_FName",	"抽样标准轻微_FNumber",	"库存检验周期天",	"库存周期检验预警提前期天",
                                   "检验方案_FInterID",	"检验方案_FBrNo",	"检验员_FName",	"检验员_FNumber",	"英文名称",	
                                   "英文规格",	"HS编码_FHSCode",	"HS编码_FNumber",	"外销税率",	"HS第一法定单位",
                                   "HS第二法定单位",	"进口关税率",	"进口消费税率",	"HS第一法定单位换算率",	"HS第二法定单位换算率",
                                   "是否保税监管",	"物料监管类型_FName",	"物料监管类型_FNumber",	"长度精度",	"体积精度",	"重量精度",
                                   "启用服务",	"生成产品档案",	"维修件",	"保修期限（月）",	"使用寿命（月）",	"物料型号",
                                   "收税类型",	"描述卖点",	"FOB价",	"控制",	"是否禁用",	"全球唯一标识内码"};
            foreach (string colName in columnNames)
            {
                DataColumn col = new DataColumn(colName, typeof(string));
                dtForErp.Columns.Add(col);
            }
            foreach (Product p in products)
            {
                DataRow rowP = dtForErp.NewRow();
               // rowP[
            }

            throw new NotImplementedException();
        }

        public IList<Product> GetByProductIdList(string[] productIdList)
        {
            return DalProduct.GetListByIdList(productIdList);


        }
        public IList<Product> GetListDiabledProducts()
        {
            return DalProduct.GetListDiabledProducts();


        }
        
    }
}
