using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NModel;
using NDAL;
using System.Data;
namespace NBiz
{
    public class SupplierSync : BLLBase<Supplier>
    {
        BizSupplier bizSupplier;
      public SupplierSync()
        {
            bizSupplier = new BizSupplier();
        }
        public void CreatExcelForImport(string templateExcelFileFolderPath, string excelSaveFolderPath)
        {

            string sql = @"
  SELECT 
CODE AS '代码',
NAME AS '名称',
'TRUE' AS '明细',
'Administrator' AS '审核人_FName',
'' AS '助记码',
nickname AS '简称',
address AS '地址', 
'使用' AS '状态_FName',
'' AS '区域_FName',
'' AS '行业_FName',
ContactPerson AS '联系人',
phone AS '电话',
'' AS '移动电话',
'' AS '传真',
'' AS '邮编',
'' AS '邮件地址',
'' AS '开户银行',
'' AS '银行账号',
'' AS '税务登记号',
'0' AS '增值税率(%)',
'' AS '国家',
'' AS '省份_FName',
'' AS '省份_FNumber',
'' AS '法人代表',
'0' AS '折扣',
'' AS '供应商分类_FName',
'' AS '采购模式_FName',
'' AS '采购模式_FNumber',
'*' AS 'VMI仓_FName',
'*' AS 'VMI仓_FNumber',
'' AS '受托代销虚仓_FName',
'' AS '受托代销虚仓_FNumber',
'0' AS '分支机构信息',
'' AS '注册商标',
'' AS '营业执照',
'' AS '注册日期',
'' AS '批准日期',
'' AS '生效日期',
'73415' AS '失效日期',
'' AS '供应商等级_FName',
'' AS '供应类别_FName',
'' AS '公司类别_FName',
'FALSE' AS '交货自动生成收货单据',
'FALSE' AS '自动确认订单',
'FALSE' AS '启用供应商协同',
'*' AS '结算币种_FName',
'*' AS '结算币种_FNumber',
'*' AS '结算方式_FName',
'*' AS '结算方式_FNumber',
'' AS '应付账款科目代码_FNumber',
'' AS '预付账款科目代码_FNumber',
'' AS '其他应付账款科目代码_FNumber',
'' AS '应交税金科目代码_FNumber',
'' AS '应收账款科目代码_FNumber',
'' AS '预收账款科目代码_FNumber',
'' AS '其他应收账款科目代码_FNumber',
'' AS '优惠政策',
'*' AS '分管部门_FName',
'*' AS '分管部门_FNumber',
'*' AS '专营业务员_FName',
'*' AS '专营业务员_FNumber',
'' AS '最后交易日期',
'0' AS '最后交易金额',
'' AS '最后付款日期',
'0' AS '最后付款金额',
'0' AS '最大交易金额',
'0' AS '最大预付比率(%)',
'' AS '付款条件_FName',
'' AS '付款条件_FNumber',
'FALSE' AS '应付冻结',
englishname AS '名称-英文',
''  AS '英文地址',
'' AS '海关注册码',
'*' AS '国别地区_Fname',
'*' AS '国别地区_FNumber',
'' AS '保税监管类型_FName',
'' AS '保税监管类型_FNumber',
'' AS '企业性质_FName',
'' AS '质量管理体系',
'0' AS '控制',
'0' AS '是否禁用',
id  AS '全球唯一标识内码'
FROM supplier 

";
           
            System.Data.DataSet ds = ExecuteSql(sql);
            // Assert.AreEqual(19, ds.Tables[0].Rows.Count);
            DataExport t = new DataExport();
            t.HeaderRows = 0;
            t.XSLFilePath = templateExcelFileFolderPath+"供应商导入模板.xls";
            t.DataToExport = ds;
            t.CreateWorkBook();
            string fileName = DateTime.Now.ToString("yyyyMMdd-hhmmss") + ".xls";
            System.IO.FileStream fsAdded = new System.IO.FileStream(excelSaveFolderPath + "Supplier_" + fileName, System.IO.FileMode.CreateNew);
            t.Book.Write(fsAdded);
        }


       

    }
}
