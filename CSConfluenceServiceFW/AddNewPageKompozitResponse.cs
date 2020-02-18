using CSConfluenceCapFW;
using Modul.Final.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSConfluenceServiceFW
{
    public class AddNewPageKompozitResponse : Ac4yServiceResponse
    {
        public IsPageExistsResult IsPageExistsResult { get; set; }
        public AddNewPageResult AddNewPageResult { get; set; }
        public DeletePageResult DeletePageResult { get; set; }
    }
}
