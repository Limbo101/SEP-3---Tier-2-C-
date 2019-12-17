using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sep3_T2_BusinessLogic.Model
{
    [Serializable]
    public class Movie
    {
        public string title { get; set; }
        public string duration { get; set; }
        public int starthour { get; set; }
        public string Date { get; set; }
    }
}
