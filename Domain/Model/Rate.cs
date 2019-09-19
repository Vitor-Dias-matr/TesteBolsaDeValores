using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Model
{
    public class Rate
    {
        public int IdRate { get; set; }
        public string Symbol { get; set; }
        public int Rates { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
