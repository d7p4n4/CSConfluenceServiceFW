﻿using Modul.Final.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSConfluenceServiceFW
{
    public class IsPageExistsRequest : Ac4yServiceRequest
    {
        public string Password { get; set; }
        public string Username { get; set; }
        public string URL { get; set; }
        public string SpaceKey { get; set; }
        public string PageId { get; set; }
    }
}
