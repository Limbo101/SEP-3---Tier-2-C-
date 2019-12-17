using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sep3_T2_BusinessLogic.Model
{
    [Serializable]
    public class Booking
    {
        public string username { get; set; }
        public string title { get; set; }
        public string date { get; set; }
        public string hour { get; set; }

        public Booking(string User, string MovieName, string date, string hour)
        {
            this.username = User;
            this.title = MovieName;
            this.date = date;
            this.hour = hour;
        }

    }
}
