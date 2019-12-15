using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sep3_T2_BusinessLogic.Model
{
    public class Client
    {

        public string username { get; set; }
        public string password { get; set; }

        public Client(string username, string password)
        {
            this.username = username;
            this.password = password;
        }
    }
}
