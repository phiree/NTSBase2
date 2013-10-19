using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NModel
{
public    class ProductCollection
    {
    public ProductCollection()
    {
        CreateTime = LastUpdateTime = DateTime.Now;
        Products = new List<Product>();
        IsDefault = false;
        CollectionName = string.Empty;
        
    }
    public virtual Guid Id { get; set; }
    public virtual Guid UserId { get; set; }
    public virtual string CollectionName { get; set; }
    public virtual IList<Product> Products { get; set; }
    public virtual DateTime CreateTime { get; set; }
    public virtual DateTime LastUpdateTime { get; set; }
    public virtual bool IsDefault { get; set; }
    }


}
