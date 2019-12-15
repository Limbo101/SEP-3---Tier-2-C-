using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sep3_T2_BusinessLogic.Model
{
    [Serializable]
    public class Booking
    {
        public string User { get; set; }
        public string MovieName { get; set; }
        public string Cinema { get; set; }
        public string Date { get; set; }

        public Booking(string User, string MovieName, string cinema, string date)
        {
            this.User = User;
            this.MovieName = MovieName;
            this.Cinema = cinema;
            this.Date = date;
        }

    }
}
