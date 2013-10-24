using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NModel
{
    /// <summary>
    /// 展区位置
    /// </summary>
    public class SR_Position
    {
        public SR_Position()
        {
            ChildrenPosition = new List<SR_Position>();
        }
        public virtual Guid Id { get; set; }
        public virtual string Name { get; set; }
        public virtual SR_Position ParentPosition { get; set; }
        public virtual IList<SR_Position> ChildrenPosition { get; set; }
        public virtual string PositionCode { get; set; }
        public virtual string Description { get; set; }
    }
}
