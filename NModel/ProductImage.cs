using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NModel
{
    //产品图片对应表
   public class ProductImage
    {
       public virtual Guid Id { get; set; }
       //文件名称,不包含路径. 路径根据配置或约定由前台拼出
       public virtual string ImageName { get; set; }
       //图片的tag. 如 主图, A图.
       public virtual string Tag { get; set; }
       //图片的指纹
       public virtual string HashCode { get; set; }
       
    }
}
