using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP.NET_VUEJS.Models
{
    public class Contact
    {
        public int id{set;get;}
        public string name{set;get;}
        public string gender { set; get; }
        public string company { set; get; }
        public string phonenumber{set;get;}
        public DateTime createdtime { set; get; }
    }
}
