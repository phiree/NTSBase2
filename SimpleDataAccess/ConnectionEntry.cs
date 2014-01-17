using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;

using System.Linq;
using System.Xml;
using System.Xml.Linq;
namespace DataAccess
{
    public sealed class ConnectionEntry
    {
       // XMLHelper _xmlHelper;// = new XMLHelper();
       

        #region [Constructor/Destructor]

        private ConnectionEntry()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        #endregion

        #region [Static Methods]

        public static string SQLConnectionString
        {
            get
            {
               
                    return ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
                
                
            }
        }

        #endregion
    }
}