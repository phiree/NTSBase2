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
            CreateTime = LastUpdateTime = DateTime.Now;
            ProductImageList = new List<ProductImage>();
            ProductMultiLangues = new List<ProductLanguage>();
        }
        public virtual Guid Id { get; set; }
        public virtual string Name
        {
            get
            {
                string name = string.Empty;
                foreach (ProductLanguage pl in ProductMultiLangues)
                {
                    name += pl.Language + "_" + pl.Name + "|";
                }
                return name.TrimEnd('|');
            }
            
        }
        public virtual string NTSCode { get; set; }
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
        [Description("最小起定量")]
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
        /// 币种
        /// </summary>
        public virtual IList<ProductImage> ProductImageList { get; set; }
        /// <summary>
        /// 导入日志
        /// </summary>
        public virtual ImportOperationLog ImportOperationLog { get; set; }

        public virtual IList<ProductLanguage> ProductMultiLangues { get; set; }
        //产品图片的名称.
        public virtual string BuildImageName(string extensionWithDot)
        {
            string imageName = ModelNumber + "__" + SupplierCode;
            imageName = NLibrary.StringHelper.ReplaceInvalidChaInFileName(imageName, "$");
            imageName = imageName + "__" + Guid.NewGuid().ToString();
            return imageName + extensionWithDot;
        }

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
            foreach (ProductLanguage piNew in newPro.ProductMultiLangues)
            {
                //如果该语言不存在 则增加
                var pll=ProductMultiLangues.Where(x => x.Language == piNew.Language).ToList();
                if ( pll.Count == 0)
                {
                    ProductMultiLangues.Add(piNew);
                }
                else  //更新
                {
                    if (pll.Count == 1)
                    {
                        ProductMultiLangues[0].UpdateByNewVersion(piNew);
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
        public virtual bool UpdateImageList(string newImagePath, string imageSavePath)
        {

            bool isAllDiff = true;

            foreach (ProductImage pi in ProductImageList)
            {
                bool isSame = ImageCompare.CompareMemCmp(newImagePath, imageSavePath + pi.ImageName);
                isAllDiff = !isSame && isAllDiff;

            }
            if (isAllDiff)
            {
                string imageNewName = BuildImageName(Path.GetExtension(newImagePath));
                ProductImage piNew = new ProductImage { ImageName = imageNewName, Tag = string.Empty };
                System.IO.File.Copy(newImagePath, imageSavePath + imageNewName, true);
                ProductImageList.Add(piNew);
            }
            return !isAllDiff;
        }
    }
}
