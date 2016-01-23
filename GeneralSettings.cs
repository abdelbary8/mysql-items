using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySQLbase
{
    public class GeneralSettings
    {
        public static string ConnectionString {
            get {
                return "Server=localhost;Database=db;Uid=user;Pwd=pass;";
            }
        }

    }
}
