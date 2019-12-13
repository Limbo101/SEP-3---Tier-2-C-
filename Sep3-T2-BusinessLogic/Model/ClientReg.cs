using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sep3_T2_BusinessLogic.Model
{
    public class ClientReg
    {
        public string username { get; set; }
        public string password { get; set; }
        public string email { get; set; }

        public ClientReg() { }

        public ClientReg(string user, string pas, string em)
        {
            this.username = user;
            this.password = pas;
            this.email = em;
        }
    }
}
