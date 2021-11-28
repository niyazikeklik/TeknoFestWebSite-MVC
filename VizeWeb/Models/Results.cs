using System.Collections.Generic;

namespace VizeWeb.Models
{
    public class Results
    {
        public class TakimResult
        {
            public string Name { get; set; }
            public int TakimUyeSayisi { get; set; }
            public List<string> TakimUyeleri { get; set; }
        }
    }
}
