using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NModel.Enums
{
    /// <summary>
    /// 产品状态
    /// </summary>
    public enum ProductState
    {
        /// <summary>
        /// 正常
        /// </summary>
        Normal,
        /// <summary>
        /// 过期
        /// </summary>
        Expired,
        /// <summary>
        /// 禁用
        /// </summary>
        Disabled
    }
    /*多語言版本的屬性值*/
    public enum ClassType
    {
        Product,
        Supplier
    }
    //
    public enum PropertyType
    {
        ProductName,
        ProductDescription,
        ProductParameters
    }
    public enum LanguageType
    {
        Chinese,
        English
    }

    /// <summary>
    /// 数据库内 已存在数据  操作
    /// 
    /// </summary>
    public enum OperationWhenExists
    {
        update,//更新数据
        skip,//跳过
        throwException//抛出错误
    }
    //图片导出的结构
    public enum ImageOutPutStratage
    {
        SupplierName_ModelNumber,// 供应商/型号.扩展名
        Category_NTsCode,//分类/ntscode.扩展名
        Supplier_OriginalName// 供应商/原始文件名
    }

    public enum StockStatus
    {
        Normal, //正常, 
        Broken,//已损坏
        Missing,//已遗失
        Borrowed,//已借出
        Returned //已归还给供应商

    }
    /// <summary>
    /// 单据类型.需要审核/历史记录的数据处理以单据形式反映.
    /// </summary>
    public enum BillType
    {
        //产品报价单 上传 
        //导入单
    }

    /// <summary>
    /// 产品和ERP同步状态
    /// </summary>
    public enum SyncState
    {
        Added,//已增加
        Modified,//已修改
        Synced//已同步
    }
}
