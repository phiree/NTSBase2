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
    public class Product
    {
        public Product()
        {
            State = ProductState.Normal;
            SyncState = SyncState.Added;
            CreateTime = LastUpdateTime = DateTime.Now;
            ProductImageList = new List<ProductImage>();
            ProductMultiLangues = new List<ProductLanguage>();
        }
        public virtual Guid Id { get; set; }
        private string name;
         [Description("产品名称")]
        public virtual string Name
        {
            get
            {
                if (ProductMultiLangues.Count == 1)
                    return ProductMultiLangues[0].Name;

                foreach (ProductLanguage pl in ProductMultiLangues)
                {
                    name += "(" + pl.Language + ")" + pl.Name + "<br/>";
                }
                return name.TrimEnd("<br/>".ToCharArray());
            }
            protected internal set { name = value; }
        }
         private string unit;
           [Description("单位")]
        public virtual string Unit
        {
            get
            {
                if (ProductMultiLangues.Count == 1)
                    return ProductMultiLangues[0].Unit;
               
                foreach (ProductLanguage pl in ProductMultiLangues)
                {
                    unit += "(" + pl.Language + ")" + pl.Unit + "<br/>";
                }
                return unit.TrimEnd("<br/>".ToCharArray());
            }
            protected internal set { unit = value; }

        }
           private string productParameters;
           [Description("规格参数")]
        public virtual string ProductParameters
        {
            get
            {
                if (ProductMultiLangues.Count == 1)
                    return ProductMultiLangues[0].ProductParameters;
                foreach (ProductLanguage pl in ProductMultiLangues)
                {
                    productParameters += "(" + pl.Language + ")" + pl.ProductParameters + "<br/>";
                }
                return productParameters.TrimEnd("<br/>".ToCharArray());
            }
            protected internal set { productParameters = value; }

        }
           private string placeOfOrigin;
           [Description("产地")]
        public virtual string PlaceOfOrigin
        {
            get
            {
                if (ProductMultiLangues.Count == 1)
                    return ProductMultiLangues[0].PlaceOfOrigin;
               
                foreach (ProductLanguage pl in ProductMultiLangues)
                {
                    placeOfOrigin += "(" + pl.Language + ")" + pl.PlaceOfOrigin + "<br/>";
                }
                return placeOfOrigin.TrimEnd("<br/>".ToCharArray());
            }
            protected internal set { placeOfOrigin = value; }

        }
           private string placeOfDelivery;
         [Description("交货地")]
        public virtual string PlaceOfDelivery
        {
            get
            {
                if (ProductMultiLangues.Count == 1)
                    return ProductMultiLangues[0].PlaceOfDelivery;
                foreach (ProductLanguage pl in ProductMultiLangues)
                {
                    placeOfDelivery += "(" + pl.Language + ")" + pl.PlaceOfDelivery + "<br/>";
                }
                return placeOfDelivery.TrimEnd("<br/>".ToCharArray());
            }
            protected internal set { placeOfDelivery = value; }

        }
         private string productDescription;
        [Description("产品描述")]
        public virtual string ProductDescription
        {
            get
            {
                if (ProductMultiLangues.Count == 1)
                    return ProductMultiLangues[0].ProductDescription;
                foreach (ProductLanguage pl in ProductMultiLangues)
                {
                    productDescription += "(" + pl.Language + ")" + pl.ProductDescription + "<br/>";
                }
                return productDescription.TrimEnd("<br/>".ToCharArray());
            }
            protected internal set { productDescription = value; }

        }
        private string memo=string.Empty;
         [Description("备注")]
        public virtual string Memo
        {
            get
            {
                if (ProductMultiLangues.Count == 1)
                    return ProductMultiLangues[0].Memo;
               foreach (ProductLanguage pl in ProductMultiLangues)
                {
                    memo += "(" + pl.Language + ")" + pl.Memo + "<br/>";
                }
                return memo.TrimEnd("<br/>".ToCharArray());
            }
            protected internal set { memo = value; }

        }
        [Description("NTS编码")]
        public virtual string NTSCode { get; set; }
          [Description("供应商编码")]
 
        public virtual string SupplierCode { get; set; }
        [Description("图片")]
        public virtual string ImageState { get; set; }
        [Description("报价日期")]
        public virtual string PriceDate { get; set; }
        [Description("报价有效期")]
        public virtual string PriceValidPeriod { get; set; }
        [Description("产品型号")]
        public virtual string ModelNumber { get; set; }

        [Description("分类编码")]
        public virtual string CategoryCode { get; set; }

        [Description("出厂价")]
        public virtual string PriceOfFactory { get; set; }
        [Description("币别")]
        public virtual string MoneyType { get; set; }
        [Description("税率")]
        public virtual decimal TaxRate { get; set; }
        [Description("最小起订量")]
        public virtual decimal OrderAmountMin { get; set; }
        [Description("生产周期")]
        public virtual decimal ProductionCycle { get; set; }


        /// <summary>
        /// 产品状态
        /// </summary>
        public virtual Enums.ProductState State { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public virtual DateTime CreateTime { get; set; }
        /// <summary>
        /// 最后一次更新时间
        /// </summary>
        public virtual DateTime LastUpdateTime { get; set; }
        /// <summary>
        /// 图片列表
        /// </summary>
        public virtual IList<ProductImage> ProductImageList { get; set; }
        /// <summary>
        /// 导入日志
        /// </summary>
        public virtual ImportOperationLog ImportOperationLog { get; set; }

        public virtual IList<ProductLanguage> ProductMultiLangues { get; set; }
        /// <summary>
        /// 和ERP系统 的 同步状态
        /// </summary>
        public virtual Enums.SyncState SyncState { get; set; }
/// <summary>
/// 同步时间
/// </summary>
        public virtual DateTime SyncTime { get; set; }
        //获取某种
        public virtual Product GetProductOfSpecialLanguage(string language)
        {
            var pl= ProductMultiLangues.Where(x => x.Language.Equals(language, StringComparison.OrdinalIgnoreCase));
          int languageVersionCount=pl.Count();
            if (languageVersionCount>1)
            {
                throw new Exception("产品信息的多语言版本有误:"+this.NTSCode+" 的"+language+" 版本有 " +languageVersionCount+" 种");
            }
            else if (languageVersionCount == 0)
            {
                return null;
            }
            Product p = new Product();
            ProductLanguage plOfThis = pl.ToArray()[0];
            p.Memo = plOfThis.Memo ?? string.Empty;
            p.Name = plOfThis.Name; 
          p.PlaceOfDelivery=   plOfThis.PlaceOfDelivery ;
          p.PlaceOfOrigin=  plOfThis.PlaceOfOrigin ;
          p.ProductDescription = plOfThis.ProductDescription;
          p.ProductParameters = plOfThis.ProductParameters;
          p.Unit = plOfThis.Unit;


          p.CategoryCode = this.CategoryCode;
          p.CreateTime = this.CreateTime;
          p.Id = this.Id;
          p.ImageState = this.ImageState;
          p.ModelNumber = this.ModelNumber;
          p.MoneyType = this.MoneyType;
          p.NTSCode = this.NTSCode;
          p.OrderAmountMin = this.OrderAmountMin;
          p.PriceDate = this.PriceDate;
          p.PriceOfFactory = this.PriceOfFactory;
          p.PriceValidPeriod = this.PriceValidPeriod;
          p.ProductImageList = this.ProductImageList;
          p.State = this.State;
          p.ProductionCycle = this.ProductionCycle;
          p.SupplierCode = this.SupplierCode;
          p.TaxRate = this.TaxRate;
            
            return p;
        }
        //导入图片时,图片文件的命名规则. 产品图片的名称.
        public virtual string BuildImageName(string extensionWithDot)
        {
            string imageName = ModelNumber + "__" + SupplierCode;
            imageName = NLibrary.StringHelper.ReplaceInvalidChaInFileName(imageName, "$");
            imageName = imageName + "__" + Guid.NewGuid().ToString();
            return imageName + extensionWithDot;
        }

        //导出时,图片的命名命名规则
        public virtual Stack<string> BuildImageOutputName(Enums.ImageOutPutStratage imageOutPutStratage)
        {
            Stack<string> imagesToExport = new Stack<string>();
            string imageUrl = string.Empty;
            int imageCount = this.ProductImageList.Count;
            if (imageCount == 0) return imagesToExport;

            imageUrl = this.ProductImageList[0].ImageName;

            string imageExtension = Path.GetExtension(imageUrl);

            string targetFileName = string.Empty;
            switch (imageOutPutStratage)
            {
                case ImageOutPutStratage.Category_NTsCode:
                    string nameee = this.NTSCode;
                    if (string.IsNullOrEmpty(nameee))
                        nameee = Guid.NewGuid().ToString();
                    imagesToExport.Push(nameee + imageExtension);//文件名称
                    imagesToExport.Push(this.CategoryCode);
                    break;
                case ImageOutPutStratage.SupplierName_ModelNumber:
                    imagesToExport.Push(this.ModelNumber + imageExtension);//文件名称
                    imagesToExport.Push(this.SupplierCode);

                    break;   

                case  ImageOutPutStratage.Supplier_OriginalName:
                     imagesToExport.Push(imageUrl);//文件名称
                    imagesToExport.Push(this.SupplierCode);
                    break;
                default: throw new Exception("No Such Stratage");
            }
            return imagesToExport;

        }

        /// <summary>
        /// 更新现有product. 
        /// 基础资料和 多语言  
        /// </summary>
        /// <param name="newPro"></param>
        public virtual void UpdateByNewVersion(Product newPro)
        {
            //基础资料
            //如果这两者变了,那需要重新生成NTSCode
            if (newPro.CategoryCode != this.CategoryCode)
            {
                this.CategoryCode = newPro.CategoryCode;
                this.NTSCode = null;
            }
            if (newPro.SupplierCode != this.SupplierCode)
            {
                this.SupplierCode = newPro.SupplierCode;
                this.NTSCode = null;
            }
            this.ImageState = newPro.ImageState;
            this.PriceDate = newPro.PriceDate;
            this.PriceOfFactory = newPro.PriceOfFactory;
            this.PriceValidPeriod = newPro.PriceValidPeriod;
            this.ProductionCycle = newPro.ProductionCycle;
            this.TaxRate = newPro.TaxRate;
            this.LastUpdateTime = DateTime.Now;
            foreach (ProductLanguage piNew in newPro.ProductMultiLangues)
            {
                //如果该语言不存在 则增加
                var pll = ProductMultiLangues.Where(x => x.Language == piNew.Language).ToList();
                if ( pll.Count == 0)
                {
                    ProductMultiLangues.Add(piNew);
                }
                else  //更新
                {
                    if (pll.Count == 1)
                    {
                       pll[0].UpdateByNewVersion(piNew);
                    }
                    else
                    {
                        throw new Exception("同一种产品出现多条同种语言的信息.型号:"+this.ModelNumber+",供应商编码:"+this.SupplierCode);
                    }
                }
            }
        }
        /// <summary>
        /// 增加新图片
        /// </summary>
        /// <param name="newImagePath"></param>
        /// <returns>是否已包含</returns>
        public virtual void UpdateImageList(string newImagePath, string imageSavePath)
        {

            //通过判断图片是否相同来决定是 增加图片 还是 更新.
            //bool isAllDiff = true;

            //foreach (ProductImage pi in ProductImageList)
            //{
            //    bool isSame = true;// ImageCompare.CompareMemCmp(newImagePath, imageSavePath + pi.ImageName);
            //    isAllDiff = !isSame && isAllDiff;

            //}
            
            if (ProductImageList.Count==0)// isAllDiff)
            {
                string imageNewName = BuildImageName(Path.GetExtension(newImagePath));
                ProductImage piNew = new ProductImage { ImageName = imageNewName, Tag = string.Empty };
                System.IO.File.Copy(newImagePath, imageSavePath + imageNewName, true);
                ProductImageList.Add(piNew);
            }
           // return !isAllDiff;
        }
    }
}
