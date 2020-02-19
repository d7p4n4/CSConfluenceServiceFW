using CSConfluenceCapFW;
using Modul.Final.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSConfluenceServiceFW
{
    public class UpdateOrAddPageCompositeResponse : Ac4yServiceResponse
    {
        public AddNewPageResult AddNewPageResult { get; set; }
        public UpdatePageResult UpdatePageResult { get; set; }
    }
}
