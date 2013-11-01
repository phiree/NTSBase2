using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NModel;
namespace NBiz
{
    public class BizRole:BLLBase<NModel.Role>
    {
        NDAL.DALRole dalRole = new NDAL.DALRole();
        public IList<NModel.Role> GetALl()
        {
            return GetAll<Role>();
        }
        public new void Delete(Role role)
        {
            dalRole.Delete(role);
        }
    }
}
