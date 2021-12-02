using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASC.Web.Configuration
{
    public class ApplicationSettings
    {
        public string ApplicationTitle { get; set; }
        public String AdminEmail { get; set; }
        public String AdminName { get; set; }
        public String AdminPassword { get; set; }
        public string EngineerEmail { get; set; }
        public string EngineerName { get; set; }
        public string EngineerPassword { get; set; }
        public String Roles { get; set; }
        public string SMTPServer { get; set; }
        public int SMTPPort { get; set; }
        public string SMTPAccount { get; set; }
        public string SMTPPassword { get; set; }
    }
}
