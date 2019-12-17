using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sep3_T2_BusinessLogic.Model
{
    [Serializable]
    public class Movie
    {
        public string Title { get; set; }
        public string Cinema { get; set; }
        public string Duration { get; set; }
        public int StartHour { get; set; }
        public string Date { get; set; }
    }
}
