using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Festival.model
{
    class LineUp
    {
        public int ID { get; set; }
        public DateTime Date { get; set; }
        public DateTime From { get; set; }
        //public string From { get; set; }
        public DateTime Until { get; set; }
        //public string Until { get; set; }
        public Stage Stage { get; set; }
        public Band Band { get; set; }
    }
}
