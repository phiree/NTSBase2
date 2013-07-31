using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NModel.Enums;
using System.IO;
using System.ComponentModel;
using NLibrary;
namespace NModel
{
    /// <summary>
    /// 产品信息的多语言版本
    /// </summary>
    public class ProductLanguage
    {
        public ProductLanguage()
        {
           
        }
        public virtual Guid Id { get; set; }
        public virtual Product Product { get; set; }
        /// <summary>
        /// 供应商代码
        /// </summary>
        /// 
        public virtual string Language { get; set; }

      
        [Description("产品名称")]
        public virtual string Name { get; set; }
        [Description("单位")]
        public virtual string Unit { get; set; }
        
        [Description("规格参数")]
        public virtual string ProductParameters { get; set; }

        [Description("产地")]
        public virtual string PlaceOfOrigin { get; set; }
        [Description("交货地")]
        public virtual string PlaceOfDelivery { get; set; }


        [Description("产品描述")]
        public virtual string ProductDescription { get; set; }
        [Description("备注")]
        public virtual string Memo { get; set; }

        public virtual void UpdateByNewVersion(ProductLanguage pl)
        {
            this.Memo = pl.Memo;
            this.Name = pl.Name;
            this.PlaceOfDelivery = pl.PlaceOfDelivery;
            this.PlaceOfOrigin = pl.PlaceOfOrigin;
            this.ProductDescription = pl.ProductDescription;
            this.ProductParameters = pl.ProductParameters;
            this.Unit = pl.Unit;
            
        }
    }

}
