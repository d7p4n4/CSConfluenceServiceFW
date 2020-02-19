using Modul.Final.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSConfluenceServiceFW
{
    public class UpdatePageRequest : Ac4yServiceRequest
    {
        public string Password { get; set; }
        public string Username { get; set; }
        public string URL { get; set; }
        public string PageId { get; set; }
        public string PageTitle { get; set; }
        public string VersionNumber { get; set; }
        public string Content { get; set; }

    }
}
