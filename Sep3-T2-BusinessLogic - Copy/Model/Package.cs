using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sep3_T2_BusinessLogic.Model
{
    public class Package
    {
        public string action { get; set; }
        public string data { get; set; }

        public Package(string action, string data)
        {
            this.action = action;
            this.data = data;

        }
    }
}
