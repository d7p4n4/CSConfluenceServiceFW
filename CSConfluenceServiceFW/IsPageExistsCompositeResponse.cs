using CSConfluenceCapFW;
using Modul.Final.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSConfluenceServiceFW
{
    public class IsPageExistsCompositeResponse : Ac4yServiceResponse
    {
        public IsPageExistsResult isPageExistsResult { get; set; }
        public GetIdByTitleResult GetIdByTitleResult { get; set; }
    }
}
